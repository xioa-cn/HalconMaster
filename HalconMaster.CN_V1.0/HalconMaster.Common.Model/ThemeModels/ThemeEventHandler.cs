namespace HalconMaster.Common.Model.ThemeModels;

public delegate void ThemeEventHandler(object sender, ThemeEventArgs e);

public class ThemeEventArgs(ThemesEnum newTheme,ThemesEnum? oldTheme) : EventArgs {
    public ThemesEnum NewTheme { get; } = newTheme;
    public ThemesEnum? OldTheme { get; } = oldTheme;
}