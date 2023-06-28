using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;
using PP.Library.Services;


namespace PP.Maui.ViewModels
{
    internal class ViewEmpVm : INotifyPropertyChanged
    {
        
        public Employee employee { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public Time SelectedTime { get; set; }

        public ObservableCollection<Time> TimeCard
        {
            get { return new ObservableCollection<Time>(EmployeeServices.Current.Employees[ID].TimeCard); }
        }


        public ViewEmpVm(int EmpID)
        {
            if (EmpID >= 0)
                LoadByID(EmpID);
        }

        public void LoadByID(int ID) 
        {
            employee = EmployeeServices.Current.GetEmployeeByID(ID);
            if (employee == null)
                return;
            Name = employee.name;
            Rate = employee.rate;
        }

        public void Delete()
        {
            if (SelectedTime == null)
                return;
            EmployeeServices.Current.Employees[employee.id].TimeCard.Remove(SelectedTime);
            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged("TimeCard");
        }

        public void Back()
        {
            Shell.Current.GoToAsync("//Employer");
        }



        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
