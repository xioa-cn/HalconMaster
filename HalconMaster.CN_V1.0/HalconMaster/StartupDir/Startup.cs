using CommunityToolkit.Mvvm.Messaging;
using HalconMaster.Base.Configs.SystemConfigs;
using HalconMaster.Common.Model.StartupModels;
using HalconMaster.Common.Tools.WindowsThemeTools;
using HalconMaster.ViewModels;
using HalconMaster.Views;
using HandyControl.Controls;
using XPrism.Core.DI;
using Window = System.Windows.Window;

namespace HalconMaster.StartupDir;

public partial class Startup {
    private void StartupWindow(Views.SplashScreen splashScreen) {
        var s = Enum.TryParse<IndexStatus>(SystemConfig.SystemConfigInstance?.IndexStatus, out var indexStatus);

        if (!s)
        {
            MessageBox.Show("初始化窗口异常！！！", "Error");
            Environment.Exit(0);
            return;
        }

        switch (indexStatus)
        {
            case IndexStatus.Login: {
                var vm = XPrismIoc.Fetch<LoginWindowViewModel>();
                var login = XPrismIoc.Fetch<LoginWindow>();
                if (login is null) throw new ArgumentNullException(nameof(LoginWindow));
                login.DataContext = vm;
                splashScreen.SwitchWindow(login);
                WeakReferenceMessenger.Default.Register<UseIcon>(this, OpenIcon);
                break;
            }
            case IndexStatus.Main: {
                var mainWindow =
                    XPrismIoc.FetchXPrismWindow(nameof(MainWindow));

                // 直接进入main窗口时 查看上次登录的权限
                AuthLoaded();
                splashScreen.SwitchWindow(mainWindow);
                NotifyIconInitialize();
                break;
            }
            case IndexStatus.None:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static void MainStartup(Window? splashScreen) {
        var mainWindow =
            XPrismIoc.FetchXPrismWindow(nameof(MainWindow));
        if (splashScreen is not null)
        {
            splashScreen?.SwitchWindow(mainWindow);
        }
        else
        {
            mainWindow.ShowWindowWithFade();
        }

        NotifyIconInitialize();
    }

    private void AuthLoaded() {
        // 在登录记录中查看
    }
}