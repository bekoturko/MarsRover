using HBCaseStudy.Business.Abstract.Services;
using Microsoft.Extensions.Logging;
using System;

namespace HBCaseStudy.Business.Services
{
    public class LoggingService : ILoggingService
    {
        #region constructor

        readonly ILogger<LoggingService> logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            this.logger = logger;
        }

        #endregion

        #region exception

        public void LogError(string methodName, string message, Exception ex)
        {
            var errorMessage = CreateMessage(methodName, message);

            logger.LogError(ex, errorMessage);
        }

        #endregion

        #region exception with message only

        public void LogError(string methodName, string message)
        {
            var errorMessage = CreateMessage(methodName, message);

            logger.LogError(errorMessage);
        }

        #endregion

        #region warning

        public void LogWarning(string methodName, string message)
        {
            var warnMessage = CreateMessage(methodName, message);

            logger.LogWarning(warnMessage);
        }

        #endregion

        #region info

        public void LogInformation(string methodName, string message)
        {
            var infoMessage = CreateMessage(methodName, message);

            logger.LogInformation(infoMessage);
        }

        #endregion

        #region debug

        public void LogDebug(string methodName, string message)
        {
            var debugMessage = CreateMessage(methodName, message);

            logger.LogDebug(debugMessage);
        }

        #endregion

        #region create message

        static string CreateMessage(string methodName, string message)
        {
            return $"({methodName}) - {message}";
        }

        #endregion
    }
}