using MyApp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;
        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void Run()
        {
            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();
               string result = commandInterpreter.Read(inputArgs);

                Console.WriteLine(result);

                //TODO try catch
            }


        }
    }
}
