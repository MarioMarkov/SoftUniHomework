﻿using SolidLogger.Appenders.Contracts;

namespace SolidLogger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime , string errorMessage);

        void Info(string dateTime, string errorMessage);
    }
}
