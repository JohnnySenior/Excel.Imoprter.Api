//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System;

namespace Excel.Importer.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        public void LogCritical(Exception exception);
        public void LogError(Exception exception);
    }
}
