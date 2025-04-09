using System.Configuration;
using System.Text.Json.Serialization;
using HalconMaster.Common.Model.ORMModels;
using HalconMaster.Common.ORM.EFDbContext;

namespace HalconMaster.Base.Configs.SystemConfigs;

public class SystemConfig {
    [JsonPropertyName("height")] public double Height { get; set; }
    [JsonPropertyName("width")] public double Width { get; set; }
    [JsonPropertyName("index")] public string? IndexStatus { get; set; }
    [JsonPropertyName("api")] public string? ApiBaseUrl { get; set; }
    [JsonPropertyName("auth")] public string? ViewAuthSwitch { get; set; }
    [JsonPropertyName("useSystemTheme")] public bool UseSystemTheme { get; set; }
    [JsonPropertyName("ormType")] public string? OrmType { get; set; }

    private static SystemConfig? _systemConfig;

    public static void SetDbType() {
        if (SystemConfigInstance != null && !string.IsNullOrEmpty(SystemConfigInstance.OrmType))
        {
            BaseDbContext.OrmType = Enum.Parse<OrmType>(SystemConfigInstance.OrmType);
        }
        else
        {
            throw new InvalidOperationException("未找到数据库类型配置");
        }
    }

    public static SystemConfig? SystemConfigInstance {
        get
        {
            if (_systemConfig != null) return _systemConfig;
            var settingJsonFile =
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "appSettings.json");
            var settingJsonString = System.IO.File.ReadAllText(settingJsonFile);
            _systemConfig = System.Text.Json.JsonSerializer.Deserialize<SystemConfig>(settingJsonString);


            return _systemConfig;
        }
    }
}