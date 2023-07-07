using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;

namespace PP.Library.Services
{
    public class EmployeeServices
    {
        private static EmployeeServices? _instance;

        public static EmployeeServices Current
        {
            get
            {
                if (_instance == null)
                    _instance = new EmployeeServices();
                return _instance;
            }
        }

        private List<Employee> _employees = new List<Employee>()
        {
            //new Employee() {id = 0, name="John", rate=10}
        };

        public List<Employee> Employees
        { get { return _employees; } }

        public Employee GetEmployeeByID(int id)
        {
            return _employees[id];
        }

        public void Add(Employee employee) 
        {
            _employees.Add(employee);
        }

        public void Delete(Employee employee) 
        {
            _employees.Remove(employee);
        }


    }
}
