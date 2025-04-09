using HalconMaster.Common.Model.ViewRegionModels;
using HalconMaster.NavigationModule.ViewModels;
using HalconMaster.NavigationModule.Views;
using XPrism.Core.DI;
using XPrism.Core.Modules;
using XPrism.Core.Modules.Find;
using XPrism.Core.Navigations;

namespace HalconMaster.NavigationModule;

[Module(nameof(NavigationModule))]
public class NavigationModule : IModule {
    public void RegisterTypes(IContainerRegistry containerRegistry) {
        containerRegistry
            .RegisterSingleton<INavigationService, NavigationService>();
        // containerRegistry
        //     .RegisterSingleton<IRegionManager, RegionManager>();
        containerRegistry.AddNavigations(regionManager =>
        {
            regionManager.RegisterForNavigation<MainPage, MainViewModel>(RegionName.MainRegion, "Main");
            
        });
    }

    public void OnInitialized(IContainerProvider containerProvider) {
        
    }
}