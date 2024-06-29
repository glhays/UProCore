// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.Logging;

namespace UPro.Core.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public void LogDebug(string message)=>
            this.logger.LogDebug(message);

        public void LogInformation(string message) =>
            this.logger.LogInformation(message);
        
        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);

        public void LogWarning(string message) =>
            this.logger.LogWarning(message);

        public void LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);
    }
}