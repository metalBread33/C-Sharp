using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;

namespace PP.Library.Services
{
    internal class EmployeeServices
    {
        private static EmployeeServices? _instance;

        public static EmployeeServices current
        {
            get
            {
                if (_instance == null)
                    _instance = new EmployeeServices();
                return _instance;
            }
        }

        private List<Employee> _employees = new List<Employee>();

        public Employee GetEmployeeByID(int id)
        {
            return _employees[id];
        }


    }
}
