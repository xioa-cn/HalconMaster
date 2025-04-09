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
    }

    public void OnInitialized(IContainerProvider containerProvider) {
        
    }
}