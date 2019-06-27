using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private MyAppContext context;

        private Mapper mapper;

        public SetManagerCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            int employeeId = int.Parse(inputArgs[0]);
            int managerId = int.Parse(inputArgs[1]);

            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            employee.Manager = manager;

            this.context.SaveChanges();

            mapper.CreateMappedObject<ManagerDto>(manager);

            return "Command completed successfuly";
        }
    }
}
