using Microsoft.Extensions.Logging;

namespace HalconMaster.Common.Services.LogService;

public class DbLogger : ILoggerBase {
    public static DbLogger Instance { get; set; } = new DbLogger();

    private DbLogger() {
        
    }
    public void Log(string log, LogLevel logLevel = LogLevel.Information) {
    }

    public void Log(Exception ex, LogLevel logLevel = LogLevel.Error) {
    }
}