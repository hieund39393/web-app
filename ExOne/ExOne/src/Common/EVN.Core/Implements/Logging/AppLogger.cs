﻿using EVN.Core.Interfaces.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace EVN.Core.Implements.Logging
{
    public class AppLogger : IAppLogger
    {
        private readonly ILogger _logger;

        public AppLogger(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("Logs");
        }

        public void Error(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void Error(Exception exception, params object[] args)
        {
            _logger.LogError(exception, GetExceptionMessage(exception), args);
        }

        public void Info(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void Info(Exception exception, params object[] args)
        {
            _logger.LogInformation(exception, GetExceptionMessage(exception), args);
        }

        public void Warning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void Warning(Exception exception, params object[] args)
        {
            _logger.LogWarning(exception, GetExceptionMessage(exception), args);
        }

        private static string GetExceptionMessage(Exception exception)
        {
            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
            }

            return exception.Message;
        }
    }
}
