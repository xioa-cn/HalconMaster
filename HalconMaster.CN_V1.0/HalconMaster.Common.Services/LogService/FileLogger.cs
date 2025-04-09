using Microsoft.Extensions.Logging;

namespace HalconMaster.Common.Services.LogService;

public class FileLogger : ILoggerBase {
    public static FileLogger Instance { get; set; } = new FileLogger();

    private FileLogger() {
        
    }
    public void Log(string log, LogLevel logLevel = LogLevel.Information) {
    }

    public void Log(Exception ex, LogLevel logLevel = LogLevel.Error) {
    }
}