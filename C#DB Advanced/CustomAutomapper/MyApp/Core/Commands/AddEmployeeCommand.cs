using AutoMapper;
using MyApp.Core.Commands.Contracts;
using MyApp.Core.ViewModels;
using MyApp.Data;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private MyAppContext context;

        private Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            string firstName = inputArgs[0];
            string lastName = inputArgs[1];
            decimal salary = decimal.Parse(inputArgs[2]);

          
            //validate

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };
            //look
            context.Employees.Add(employee);
            context.SaveChanges();

            var employeeDto = mapper.CreateMappedObject<EmpoyeeDto>(employee);

            string result = $"Registered successfuly: {employeeDto.FirstName} {employeeDto.LastName} - {employeeDto.Salary:f2}!";

            return result;
        }
    }
}
