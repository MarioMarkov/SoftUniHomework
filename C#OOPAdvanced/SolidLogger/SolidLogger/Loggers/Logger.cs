namespace SolidLogger.Loggers
{
    using SolidLogger.Appenders.Contracts;
    using Loggers.Contracts;
    using System;
    using SolidLogger.Enums;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;
        public Logger(IAppender consoleAppender, IAppender fileAppender) : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }
        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
            
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Error, errorMessage);
        }
        public void Critical(string dateTime, string criticalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Critical, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Fatal, fatalMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Info, infoMessage);
        }
        public void Warning(string dateTime, string infoMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Warning, infoMessage);
        }


        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
           
            this.fileAppender?.Append(dateTime, reportLevel, message);
            this.consoleAppender.Append(dateTime, reportLevel, message);
        }
    }
}
