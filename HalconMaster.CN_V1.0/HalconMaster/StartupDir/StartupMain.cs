﻿using System.Reflection;
using System.Windows;
using HalconMaster.Base.Configs.SystemConfigs;
using HalconMaster.Common.Lang;
using HalconMaster.Common.Model.LangModels;
using HalconMaster.Common.Model.StartupModels;
using HalconMaster.Common.Services.StartupServices;
using HalconMaster.Common.Tools.DispatcherTools;
using HalconMaster.Common.Tools.WindowsThemeTools;
using HalconMaster.ViewModels;
using HalconMaster.Views;
using XPrism.Core.DataContextWindow;
using XPrism.Core.DI;
using XPrism.Core.Events;
using XPrism.Core.Modules.Find;

namespace HalconMaster.StartupDir;

public partial class Startup(Application application) : IAppStartup {
    private Application App { get; set; } = application;

    private static readonly Views.SplashScreen _splashScreen;

    static Startup()
    {
        _splashScreen = new Views.SplashScreen();
        _splashScreen.ShowWindowWithFade();
    }
    
    public void OnStartUp(StartupEventArgs e) {
        LangManager.Instance.SwitchLanguage("zh-cn");
        SystemConfig.SetDbType();
        SystemTheme(); 
        Detect(); 
        DispatcherHelper.Initialize();
       
        Task.Run(() =>
        {
            Thread.Sleep(2000);
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                ContainerLocator.Container.RegisterTransient<LoginWindow>();
                ContainerLocator.Container.RegisterEventAggregator<EventAggregator>();
                ContainerLocator.Container.RegisterSingleton<LoginWindowViewModel>();
                ContainerLocator.Container.AutoRegisterByAttribute(
                    Assembly.Load("HalconMaster")); 
                ContainerLocator.Container
                    .RegisterSingleton<IModuleFinder>(new DirectoryModuleFinder()) 
                    .RegisterMeModuleManager(manager =>
                    {
                        manager.LoadModulesConfig(AppDomain.CurrentDomain.BaseDirectory);
                    }); 
                ContainerLocator.Container.AutoRegisterByAttribute<XPrismViewModelAttribute>(
                    Assembly.Load("HalconMaster")); 
                ContainerLocator.Container.Build();
                var applicationStartupMode = StartupCommandLine(e.Args); 
                if (applicationStartupMode == ApplicationStartupMode.Debug)
                {
                    Environment.Exit(0);
                }

               
                StartupWindow(_splashScreen);
            });
        });
    }
}