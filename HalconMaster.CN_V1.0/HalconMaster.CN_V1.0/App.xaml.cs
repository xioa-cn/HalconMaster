using System.Windows;
using HalconMaster.StartupDir;

namespace HalconMaster.CN_V1._0;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        Startup startup = new Startup(this);
        startup.OnStartUp(e);

        base.OnStartup(e);
    }
}