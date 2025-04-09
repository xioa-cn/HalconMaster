using System.Windows;

namespace HalconMaster.Common.Tools.LangTools;

public class DynamicResourceEx : DynamicResourceExtension {
    public DynamicResourceEx() {
    }

    public DynamicResourceEx(object resourceKey) : base(resourceKey) {
    }

    public object? FallbackValue { get; set; }

    public override object ProvideValue(IServiceProvider? serviceProvider) {
        var resources = Application.Current.Resources.MergedDictionaries;
        if (
            !resources.Contains(ResourceKey))
        {
            if (FallbackValue is string fallbackValue)
            {
                var fallbackDict = new ResourceDictionary { { ResourceKey, FallbackValue } };
                Application.Current.Resources.MergedDictionaries.Add(fallbackDict);
            }
            else
            {
                // 仅支持string 类型默认值
                throw new ArgumentException(nameof(FallbackValue));
            }
        }

        var value = base.ProvideValue(serviceProvider);

        return value;
    }
}