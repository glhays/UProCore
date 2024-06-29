// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System;

namespace UPro.Core.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogDebug(string message);
        void LogInformation(string message);
        void LogCritical(Exception exception);
    }
}