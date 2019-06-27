using SolidLogger.Appenders.Contracts;
using SolidLogger.Appenders.Factory;
using SolidLogger.Appenders.Factory.Contracts;
using SolidLogger.Core.Contracts;
using SolidLogger.Enums;
using SolidLogger.Layouts.Contracts;
using SolidLogger.Layouts.Factory;
using SolidLogger.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layotFactory;
        private ReportLevel reportLevel;
        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layotFactory = new LayoutFactory();
        }
        public void AddAppender(string[] args)
        {
            string type = args[0];
            string layoutType = args[1];
            ILayout layout = this.layotFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(type, layout);
            reportLevel = ReportLevel.Info;
            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2],true);
            }
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0],true);
            string dateTime = args[1];
            string message = args[2];
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
