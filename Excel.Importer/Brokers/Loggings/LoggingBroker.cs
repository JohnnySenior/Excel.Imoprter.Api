//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.Extensions.Logging;
using System;

namespace Excel.Importer.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public void LogCritical(Exception exception) =>
        this.logger.LogCritical(exception.Message, exception);

        public void LogError(Exception exception) =>
        this.logger.LogError(exception.Message, exception);
    }
}
