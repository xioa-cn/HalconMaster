using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using HalconMaster.Common.Model.StartupModels;
using HalconMaster.ViewModels;
using Hardcodet.Wpf.TaskbarNotification;
using XPrism.Core.DI;

namespace HalconMaster.StartupDir;

public partial class Startup {
    private static TaskbarIcon? _notifyIcon;
    private static NotifyViewModel? NotifyViewModel { get; set; }
    public static Window? MainWindow { get; private set; }
    public static void MainShow()
    {
        if (MainWindow is not null)
        {
            MainWindow.Visibility = Visibility.Visible;
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }
        else
        {
            var windows = Application.Current.Windows;
            foreach (Window item in windows)
            {
                if (item.GetType() != typeof(MainWindow)) continue;
                MainWindow = item;
                item.Visibility = Visibility.Visible;
                item.WindowState = WindowState.Normal;
                item.Activate();
                return;
            }
        }
    }

    private static void DisposeNotifyIcon()
    {
        _notifyIcon?.Dispose();
        _notifyIcon = null;
    }
    public void UseNotifyIcon()
    {
        NotifyIconInitialize();
    }
    
    public void NotifyIconInitialize()
    {
        if (NotifyViewModel is not null)
            return;
        NotifyViewModel = XPrismIoc.Fetch<NotifyViewModel>();
        Binding binding = new Binding();
        binding.Source = NotifyViewModel;
        binding.Path = new PropertyPath("Title");
        binding.Mode = BindingMode.TwoWay;
        _notifyIcon = new TaskbarIcon
        {
            DataContext = NotifyViewModel,
            Icon = new Icon("Assets/logo/logo.ico"),
            ContextMenu = new ContextMenu()
            {
                Style = (Style)App.FindResource("Notify")!
            },
        };
        _notifyIcon.SetBinding(TaskbarIcon.ToolTipTextProperty, binding);
        _notifyIcon.DoubleClickCommand = new RelayCommand(MainShow);
    }
    
    protected  void OnExit(ExitEventArgs e)
    {
        _notifyIcon?.Dispose();
    }

    private void OpenIcon(object recipient, UseIcon message)
    {
        UseNotifyIcon();
    }
}