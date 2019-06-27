namespace _03BarracksFactory.Core
{
    using System;
    using System.Reflection;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        
        private string InterpredCommand(string[] data, string commandName)
        {
            Type type = Type.GetType("P03_BarraksWars.Core.CommandList."+ commandName+"Command");
            var instance = Activator.CreateInstance(type,new object[] { data,repository,unitFactory});
            
            var method = type.GetMethod("Execute",(BindingFlags)62);
            string result = method.Invoke(instance, null).ToString();

            return result;

            //string result = string.Empty;
            //switch (commandName)
            //{
            //    case "add":
            //        result = this.AddUnitCommand(data);
            //        break;
            //    case "report":
            //        result = this.ReportCommand(data);
            //        break;
            //    case "fight":
            //        //Environment.Exit(0);
            //        break;
            //    default:
            //        throw new InvalidOperationException("Invalid command!");
            //}
            //return result;
        }
        
    }
}
