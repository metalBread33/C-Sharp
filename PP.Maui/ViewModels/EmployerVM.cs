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
    class EmployerVM : INotifyPropertyChanged
    {
        public Employee employee;

        public Employee SelectedEmployee { get; set; }

        public ObservableCollection<Employee> Employees
        {
            get { return new ObservableCollection<Employee>(EmployeeServices.Current.Employees); }
        }

        public void RefreshView()
        {
            NotifyPropertyChanged("Employees");
        }

        public void Delete()
        {
            if (SelectedEmployee!= null)
                EmployeeServices.Current.Delete(SelectedEmployee);
            RefreshView();
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
