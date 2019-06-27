namespace SolidLogger.Appenders
{
    using SolidLogger.Appenders.Contracts;
    using SolidLogger.Enums;
    using SolidLogger.Layouts.Contracts;
    using SolidLogger.Loggers.Contracts;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        
        private readonly ILogFile logFile;
        private const string path = "log.txt";

        public FileAppender(ILayout layout, ILogFile logFile):base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessagesCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + "\n";
                this.logFile.Write(content);
                File.AppendAllText(path, content);
            }
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
