﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace WideWorldImporters.Server.Api.Infrastructure.Logging
{
    public static class LoggerExtensions
    {
        public static bool IsDebugEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Debug);
        }

        public static bool IsCriticalEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Critical);
        }

        public static bool IsErrorEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Error);
        }

        public static bool IsInformationEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Information);
        }

        public static bool IsTraceEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Trace);
        }

        public static bool IsWarningEnabled<TLoggerType>(this ILogger<TLoggerType> logger)
        {
            return logger.IsEnabled(LogLevel.Warning);
        }

        public static void TraceMethodEntry<TLoggerType>(this ILogger<TLoggerType> logger, [CallerFilePath] string? callerFilePath = null, [CallerLineNumber] int? callerLineNumber = null, [CallerMemberName] string callerMemberName = "")
        {
            if (logger.IsTraceEnabled())
            {
                logger.LogTrace("Method Entry (CallerFilePath = {CallerFilePath}, CallerLineNumber = {CallerLineNumber}, CallerMemberName = {CallerMemberName})",
                    callerFilePath, callerLineNumber, callerMemberName);
            }
        }
    }
}
