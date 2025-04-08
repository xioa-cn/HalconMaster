using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using HalconMaster.Common.Model;

namespace HalconMaster.Common.Themes;

public partial class ThemeManager : BindableBase {
    private static ThemeManager? _instance;
    public static ThemeManager Instance => _instance ??= new ThemeManager();

    private ThemeManager() {
        // 默认使用深色主题
        IsDarkTheme = false;
        ApplyTheme();
    }

    [ObservableProperty] private bool _isDarkTheme;

    partial void OnIsDarkThemeChanged(bool value) {
        ApplyTheme();
    }

    private static readonly ResourceDictionary HcLightTheme = new() {
        Source = new Uri("pack://application:,,,/HandyControl;component/Themes/SkinDefault.xaml")
    };

    private static readonly ResourceDictionary HcDarkTheme = new() {
        Source = new Uri("pack://application:,,,/HandyControl;component/Themes/SkinDark.xaml")
    };

    // 自定义主题资源
    private static readonly ResourceDictionary CustomLightTheme = new() {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Themes;component/Themes/DefaultTheme.xaml")
    };

    private static readonly ResourceDictionary CustomDarkTheme = new() {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Themes;component/Themes/DarkTheme.xaml")
    };


    private void UpdateThemeResource(Collection<ResourceDictionary> resources,
        ResourceDictionary lightTheme, ResourceDictionary darkTheme, bool hc = false) {
        if (hc)
        {
            // 1. 先移除所有HandyControl相关资源
            var hcResources = resources.Where(x =>
                x.Source?.ToString().Contains("/HandyControl;component/") ?? false).ToList();
            foreach (var resource in hcResources)
            {
                resources.Remove(resource);
            }

            // 2. 重新添加HandyControl基础资源
            resources.Add(new ResourceDictionary {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });
        }


        // 添加新主题
        resources.Add(IsDarkTheme ? darkTheme : lightTheme);
    }

    private void ApplyTheme() {
        var app = Application.Current;
        if (app == null) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            var resources = app.Resources.MergedDictionaries;

            // 更新HandyControl主题
            UpdateThemeResource(resources, HcLightTheme, HcDarkTheme, true);

            // 更新自定义主题
            UpdateThemeResource(resources, CustomLightTheme, CustomDarkTheme);

            // 更新窗口背景
            UpdateWindowBackground();
        });
    }

    private void UpdateWindowBackground() {
        if (Application.Current.MainWindow?.Template.FindName("MainBorder",
                Application.Current.MainWindow) is Border border)
        {
            border.Background = Application.Current.Resources["Background.Brush"] as SolidColorBrush;
        }
    }

    private static ResourceDictionary? _currentTheme;

    public static void UseTheme(string content) {
        var app = Application.Current;
        if (app == null) return;

        // 移除当前主题（如果存在）
        if (_currentTheme != null)
        {
            app.Resources.MergedDictionaries.Remove(_currentTheme);
        }

        var themePath =
            $"pack://application:,,,/HalconMaster.Common.Themes;component/Themes/{content}Theme.xaml";
        _currentTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Absolute) };
        app.Resources.MergedDictionaries.Add(_currentTheme);
        // 更新窗口背景色
        if (Application.Current.MainWindow == null) return;
        if (Application.Current.MainWindow.Template.FindName("MainBorder",
                Application.Current.MainWindow) is Border border)
        {
            border.Background = (SolidColorBrush)Application.Current.Resources["Background.Brush"];
        }
    }
}