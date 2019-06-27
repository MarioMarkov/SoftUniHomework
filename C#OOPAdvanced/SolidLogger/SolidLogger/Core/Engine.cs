using SolidLogger.Appenders.Contracts;
using SolidLogger.Appenders.Factory.Contracts;
using SolidLogger.Core.Contracts;
using SolidLogger.Enums;
using SolidLogger.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidLogger.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
           
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                
                commandInterpreter.AddAppender(args);
            }

            while (true)
            {
                string[] args = Console.ReadLine().Split("|");
                if (args[0]== "END")
                {
                    break;
                }
                commandInterpreter.AddMessage(args);
            }

            Console.WriteLine("Logger info");
            this.commandInterpreter.PrintInfo();
        }
    }
}
