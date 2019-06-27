using SolidLogger.Appenders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddMessage(string[] args);

        void PrintInfo();
    }
}
