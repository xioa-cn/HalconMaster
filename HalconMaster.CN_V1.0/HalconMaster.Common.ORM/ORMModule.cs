using HalconMaster.Common.ORM.EFDbContext;
using HalconMaster.Common.ORM.EFDbContext.SystemDb;
using Microsoft.EntityFrameworkCore;
using XPrism.Core.DI;
using XPrism.Core.Modules;
using XPrism.Core.Modules.Find;

namespace HalconMaster.Common.ORM;

[Module(nameof(ORMModule))]
public class ORMModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance(typeof(SysDbContext), new SysDbContext());
        containerRegistry.RegisterSingleton(typeof(ISystemRepository), typeof(SystemRepository));
    }

    public async void OnInitialized(IContainerProvider containerProvider)
    {
        // var db =
        //     XPrismIoc.Fetch<ISystemRepository>();
        // //db.DbContext.Database.EnsureCreatedAsync();
        // var res = await db.DbSet.FirstOrDefaultAsync(e => e.Name == "HalconMaster");
        //
        // if (res == null)
        // {
        //     db.DbSet.Add(new SystemUser()
        //     {
        //         Name = "HalconMaster",
        //     });
        //     await db.DbContext.SaveChangesAsync();
        // }
    }
}