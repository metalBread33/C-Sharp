using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;
using PP.Library.Services;

namespace PP.Maui.ViewModels
{
    public class EditTimeVM : INotifyPropertyChanged
    {
        public int EmpID { get; set; }
        public Time time { get; set; }
        public Project project { get; set; }
        public Employee employee { get; set; }
        public int Hours { get; set; }
        public DateTime Date { get; set; }
        public string Narriative { get; set; }

        public EditTimeVM(int Empid, int t) 
        {
            EmpID = Empid;
            employee = EmployeeServices.Current.GetEmployeeByID(Empid);
            time = employee.TimeCard[t];
            project = time.project;
            Hours = time.Hours;
            Date = time.Date;
            Narriative = time.Narrative;
        }

        public void Edit ()
        {
            time.Hours= Hours;
            time.Date= Date;
            time.Narrative= Narriative;
        }

        public void Refresh ()
        {
            NotifyPropertyChanged(nameof(Date));
            NotifyPropertyChanged(nameof(Hours));
            NotifyPropertyChanged(nameof(Narriative));
        }

        public void Back()
        {
            Shell.Current.GoToAsync($"//ViewEmployee?EmpID={EmpID}");
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
