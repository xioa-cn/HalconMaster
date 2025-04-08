using System.Windows;
using HalconMaster.Common.Model.LangModels;

namespace HalconMaster.Common.Lang;

public class LangManager
{
    private static readonly ResourceDictionary ZhCn = new()
    {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Lang;component/Langs/ZH-CN.xaml")
    };

    private static readonly ResourceDictionary EnUs = new()
    {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Lang;component/Langs/EN-US.xaml")
    };

    public static void SetLanguage(SystemLanguage lang)
    {
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