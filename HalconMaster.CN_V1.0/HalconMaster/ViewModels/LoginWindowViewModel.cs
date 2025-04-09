using System.Windows;
using CommunityToolkit.Mvvm.Input;
using HalconMaster.Common.Model;
using HalconMaster.Common.Tools.WindowsThemeTools;
using HalconMaster.StartupDir;
using XPrism.Core.DI;
using XPrism.Core.Events;

namespace HalconMaster.ViewModels;

public partial class LoginWindowViewModel : BindableBase {
    public LoginWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
    }

    [RelayCommand]
    private void MainShow(Window window) {
        Startup.MainStartup(window);
    }
}