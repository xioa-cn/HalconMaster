using System.Windows;
using HalconMaster.Common.Model.LangModels;

namespace HalconMaster.Common.Lang;

public class LangManager {
    private static readonly ResourceDictionary ZhCn = new() {
        Source = new Uri("pack://application:,,,/HalconMaster.Common.Lang;component/Langs/ZH-CN.xaml")
    };
    public void SetLanguage(SystemLanguage lang) {
    }
}