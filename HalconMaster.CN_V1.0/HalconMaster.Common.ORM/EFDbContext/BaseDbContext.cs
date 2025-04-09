using System.Reflection;
using System.Runtime.Loader;
using HalconMaster.Common.Tools.LoggerTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace HalconMaster.Common.ORM.EFDbContext;

public abstract class BaseDbContext : DbContext {
    protected abstract string ConnectionString { get; }

    public bool QueryTracking {
        set
        {
            this.ChangeTracker.QueryTrackingBehavior =
                value ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
        }
    }

    protected BaseDbContext() : base() {
    }

    protected BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) {
    }

    protected void OnModelCreating(ModelBuilder modelBuilder, Type type) {
        try
        {
            //获取所有类库
            var compilationLibrary = DependencyContext
                .Default?
                .CompileLibraries
                .Where(x => !x.Serviceable && x.Type != "package" && x.Type == "project");
            if (compilationLibrary is not null)
                foreach (var compilation in compilationLibrary)
                {
                    //加载指定类
                    AssemblyLoadContext.Default
                        .LoadFromAssemblyName(new AssemblyName(compilation.Name))
                        .GetTypes().Where(x => x.GetTypeInfo().BaseType != null
                                               && x.BaseType == (type)).ToList()
                        .ForEach(t => { modelBuilder.Entity(t); });
                }

            base.OnModelCreating(modelBuilder);
        }
        catch (Exception ex)
        {
            LoggerTool.Log(ex);
        }
    }

    protected void UseDbType(DbContextOptionsBuilder optionsBuilder, string connectionString) {
    }
}