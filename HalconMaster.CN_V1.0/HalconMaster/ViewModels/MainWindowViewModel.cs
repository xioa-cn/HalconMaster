
using HalconMaster.Common.Model;
using XPrism.Core.DI;
using XPrism.Core.Navigations;

namespace HalconMaster.ViewModels;

[AutoRegister(typeof(MainWindowViewModel), ServiceLifetime.Singleton, nameof(MainWindowViewModel))]
public class MainWindowViewModel : BindableBase {
    private readonly INavigationService _navigationService;
    public MainWindowViewModel(INavigationService navigationService) {
        this._navigationService = navigationService;
    }
}