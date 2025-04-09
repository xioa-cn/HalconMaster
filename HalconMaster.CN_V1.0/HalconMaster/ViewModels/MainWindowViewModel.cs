using CommunityToolkit.Mvvm.Input;
using HalconMaster.Common.Model;
using HalconMaster.Common.Model.LoginModels;
using HalconMaster.Common.Model.ViewRegionModels;
using XPrism.Core.DI;
using XPrism.Core.Events;
using XPrism.Core.Navigations;

namespace HalconMaster.ViewModels;

[AutoRegister(typeof(MainWindowViewModel), ServiceLifetime.Singleton, nameof(MainWindowViewModel))]
public partial class MainWindowViewModel : BindableBase {
    private readonly INavigationService _navigation;
    public MainWindowViewModel(IEventAggregator eventAggregator, INavigationService navigation) : base(eventAggregator) {
        this._navigation = navigation;
        this._eventAggregator.GetEvent<LoginEvent>()
            .Subscribe<string, bool>(LoginResult, ThreadOption.UIThread, true, "Login");
        this._navigation.NavigateAsync($"{RegionName.MainRegion}/Main");
    }

    private async Task<bool> LoginResult(LoginModel arg) {
        return true;
    }

    [RelayCommand]
    private void Send() {
        var result = this._eventAggregator.GetEvent<LoginEvent>().Publish(new LoginModel() {
            UserName = "xioa"
        }, "Login").GetValue<bool>();
    }
}