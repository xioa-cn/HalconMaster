using System.Windows;
using HalconMaster.Common.Model.StartupModels;

namespace HalconMaster.Common.Services.StartupServices;

public interface IAppStartup {
    public void OnStartUp(StartupEventArgs e);
    ApplicationStartupMode StartupCommandLine(string[]? args);
    public void Detect(string memoryName = "HalconMaster");
}