using HalconMaster.Base.Configs.SystemConfigs;
using HalconMaster.Common.Themes;
using HalconMaster.Common.Tools.DispatcherTools;
using HalconMaster.Common.Tools.WindowsThemeTools;

namespace HalconMaster.StartupDir;

public partial class Startup {
    /// <summary>
    /// 应用跟随系统颜色
    /// </summary>
    public void SystemTheme() {
        if (SystemConfig.SystemConfigInstance != null && !SystemConfig.SystemConfigInstance.UseSystemTheme)
        {
            // 如果没有打开跟随系统 则默认使用浅色
            ThemeManager.Instance.IsDarkTheme = false;
            return;
        }

        SystemThemeDetector systemThemeDetector = new SystemThemeDetector();
        ThemeManager.Instance.IsDarkTheme = systemThemeDetector.IsDarkMode;
        systemThemeDetector.ThemeChanged += (sender, b) =>
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => { ThemeManager.Instance.IsDarkTheme = b; });
        };
    }
}