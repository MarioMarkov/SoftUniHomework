namespace SolidLogger
{
    using System;
    using SolidLogger.Appenders;
    using SolidLogger.Appenders.Contracts;
    using SolidLogger.Core;
    using SolidLogger.Core.Contracts;
    using SolidLogger.Enums;
    using SolidLogger.Layouts;
    using SolidLogger.Layouts.Contracts;
    using SolidLogger.Loggers;
    using SolidLogger.Loggers.Contracts;
    class StartUp
    { 
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
