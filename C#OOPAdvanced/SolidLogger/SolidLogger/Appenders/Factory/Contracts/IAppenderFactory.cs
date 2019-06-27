using SolidLogger.Appenders.Contracts;
using SolidLogger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Appenders.Factory.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
