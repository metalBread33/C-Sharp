using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Services;
using PP.Library.Models;

namespace PP.Maui.ViewModels
{
    class AddEmployeeVM
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Rate { get; set; }

        public AddEmployeeVM() { }

        public void Add()
        {
            EmployeeServices.Current.Employees.Add(
                new Employee
                {
                    id = EmployeeServices.Current.Employees.Count(),
                    name = Name,
                    rate = Rate,
                });
        }
    }
}
