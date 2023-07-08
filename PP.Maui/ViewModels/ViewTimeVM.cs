using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    class ViewTimeVM
    {
        public int EmpID { get; set; }
        public Time time { get; set; }
        public Project project { get; set; }
        public Employee employee { get; set; }
        public int Hours { get; set; }
        public DateTime Date { get; set; }
        public string Narriative { get; set; }
        
        public ViewTimeVM(int Empid, int t) 
        {
            EmpID = Empid;
            employee = EmployeeServices.Current.GetEmployeeByID(Empid);
            time = employee.TimeCard[t];
            project = time.project;
            Hours = time.Hours;
            Date = time.Date;
            Narriative = time.Narrative;
        }

        public void Bill()
        {
            project.Bills.Add(new Bill
            {
                DueDate = DateTime.Now.AddDays(7),
                TotalAmount = Hours * employee.rate
            });
            Back();
        }

        public void Back()
        {
            Shell.Current.GoToAsync($"//ViewEmployee?EmpID={EmpID}");
        }
    }
}
