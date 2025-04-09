using CommunityToolkit.Mvvm.Input;
using HalconMaster.Common.Model;
using HalconMaster.Common.Model.LoginModels;
using XPrism.Core.DI;
using XPrism.Core.Events;
using XPrism.Core.Navigations;

namespace HalconMaster.ViewModels;

[AutoRegister(typeof(MainWindowViewModel), ServiceLifetime.Singleton, nameof(MainWindowViewModel))]
public partial class MainWindowViewModel : BindableBase {
    public MainWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
        this._eventAggregator.GetEvent<LoginEvent>()
            .Subscribe<string, bool>(LoginResult, ThreadOption.UIThread, true, "Login");
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