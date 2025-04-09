using HalconMaster.Common.Model.LoggerModels;
using HalconMaster.Common.Services.LogService;
using Microsoft.Extensions.Logging;

namespace HalconMaster.Common.Tools.LoggerTools;

public static class LoggerTool {
    private static ILoggerBase[]? _logger;

    private static ILoggerBase[]? Logger => _logger ??= null;

    public static void UseLogger(LoggerType loggerType) {
        _logger = loggerType switch {
            LoggerType.All => [FileLogger.Instance, DbLogger.Instance],
            LoggerType.Db => [DbLogger.Instance],
            LoggerType.File => [FileLogger.Instance],
            _ => null
        };
    }


    public static void Log(Exception exception, LogLevel logLevel = LogLevel.Error,
        LoggerType loggerType = LoggerType.All) {
        if (Logger == null) return;
        foreach (var log in Logger)
        {
            switch (loggerType)
            {
                case LoggerType.All:
                    log.Log(ex: exception, logLevel: logLevel); break;
                case LoggerType.Db when log is DbLogger:
                    log.Log(ex: exception, logLevel: logLevel); break;
                case LoggerType.File when log is FileLogger:
                    log.Log(ex: exception, logLevel: logLevel);
                    break;
                case LoggerType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType), loggerType, null);
            }
        }
    }

    public static void Log(string lg, LogLevel logLevel = LogLevel.Information,
        LoggerType loggerType = LoggerType.All) {
        if (Logger == null) return;
        foreach (var log in Logger)
        {
            switch (loggerType)
            {
                case LoggerType.All:
                    log.Log(lg, logLevel: logLevel); break;
                case LoggerType.Db when log is DbLogger:
                    log.Log(lg, logLevel: logLevel); break;
                case LoggerType.File when log is FileLogger:
                    log.Log(lg, logLevel: logLevel);
                    break;
                case LoggerType.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType), loggerType, null);
            }
        }
    }
}