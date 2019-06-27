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
    public class ManagerInfoCommand : ICommand
    {
        private MyAppContext context;

        private Mapper mapper;

        public ManagerInfoCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public string Execute(string[] inputArgs)
        {
            int managerId = int.Parse(inputArgs[0]);

            var manager = context.Employees.Find(managerId);

            StringBuilder sb = new StringBuilder();

            var managerDto = mapper.CreateMappedObject<ManagerDto>(manager);

            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagedEmployees.Count}");
            foreach (var mangedEmployee in manager.ManagedEmployees)
            {
                sb.AppendLine($"    - {mangedEmployee.FirstName} {mangedEmployee.LastName} - ${mangedEmployee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
