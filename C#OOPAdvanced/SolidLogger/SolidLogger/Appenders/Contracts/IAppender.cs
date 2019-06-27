using SolidLogger.Enums;

namespace SolidLogger.Appenders.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        
        int MessagesCount { get;  }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
