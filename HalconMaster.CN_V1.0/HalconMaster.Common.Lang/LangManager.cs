using System.Globalization;
using System.Windows;
using HalconMaster.Common.Model.LangModels;

namespace HalconMaster.Common.Lang;

public class LangManager {
    private static LangManager? _instance;
    public static LangManager Instance => _instance ??= new LangManager();

    private LangManager() {
    }

    public event LangEventHandler? LanguageChanged;

    private static readonly ResourceDictionary ZhCn = new() {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Lang;component/Langs/ZH-CN.xaml")
    };

    private static readonly ResourceDictionary EnUs = new() {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Lang;component/Langs/EN-US.xaml")
    };

    private string? _oldLangName;

    public void SwitchLanguage(string lang) {
        _oldLangName = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        CultureInfo.CurrentUICulture = new CultureInfo(lang);
        SetLanguage(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName switch {
            "en" => SystemLanguage.EnUs, "zh" => SystemLanguage.ZhCn, _ => throw new ArgumentOutOfRangeException()
        });
        LanguageChanged?.Invoke(this,
            new LangEventArgs(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, _oldLangName));
    }


    private static void SetLanguage(SystemLanguage lang) {
        var resources = Application.Current.Resources.MergedDictionaries;

        var findResources = resources.Where(
                x => x.Source?.ToString().Contains("/HalconMaster.Common.Lang;component/") ?? false)
            .ToList();

        foreach (var itemRes in findResources)
        {
            resources.Remove(itemRes);
        }

        switch (lang)
        {
            case SystemLanguage.EnUs:
                resources.Add(EnUs);
                break;
            case SystemLanguage.ZhCn:
                resources.Add(ZhCn);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(lang), lang, null);
        }
    }
}