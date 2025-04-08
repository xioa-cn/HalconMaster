namespace HalconMaster.StartupDir;

public partial class Startup {
    public static void DisposeAppResources()
    {
        // 清理资源
        Startup.DisposeNotifyIcon();
    }

    public static void DisposeNotifyIconResources() {
        Startup.DisposeNotifyIcon();
        Startup.NotifyViewModel = null; // 释放NotifyViewModel 
    }
}