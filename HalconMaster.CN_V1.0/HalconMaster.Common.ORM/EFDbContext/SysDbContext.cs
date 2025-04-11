using HalconMaster.Common.Model.ORMModels;
using Microsoft.EntityFrameworkCore;

namespace HalconMaster.Common.ORM.EFDbContext;

public class SysDbContext : BaseDbContext
{
    protected override string ConnectionString => ConnectString.DbConnectString;

    public SysDbContext() : base()
    {
    }

    public SysDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.UseDbType(optionsBuilder, ConnectionString);
        //默认禁用实体跟踪
        //optionsBuilder = optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder, typeof(SysEntity));
    }
}