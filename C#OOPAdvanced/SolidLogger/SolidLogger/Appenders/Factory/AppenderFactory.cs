using SolidLogger.Appenders.Contracts;
using SolidLogger.Appenders.Factory.Contracts;
using SolidLogger.Layouts.Contracts;
using SolidLogger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();
            switch (typeAsLower)
            {
                case "consoleappender": return new ConsoleAppender(layout);

                case "fileappender": return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type");
                    break;
            }
        }
    }
}
