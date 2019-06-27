using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModels
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.ManagedEmployees = new List<EmpoyeeDto>();   
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<EmpoyeeDto> ManagedEmployees { get; set; }
    }
}
