using Microsoft.Extensions.Logging;

namespace HalconMaster.Common.Services.LogService;

public interface ILoggerBase {
    void Log(string log, LogLevel logLevel = LogLevel.Information);
    void Log(Exception ex, LogLevel logLevel = LogLevel.Error);
}