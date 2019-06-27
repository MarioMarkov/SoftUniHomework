using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

         void Write(string message);
    }
}
