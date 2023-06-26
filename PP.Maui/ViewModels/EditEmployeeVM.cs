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
    internal class EditEmployeeVM : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }

       public EditEmployeeVM(int id)
        {
            if (id >=0) 
                LoadByID(id);
        }

        public void LoadByID (int id)
        {
            editEmployee = EmployeeServices.Current.GetEmployeeByID(id);

            if(editEmployee !=null) 
            {
                Name = editEmployee.name;
                Rate=editEmployee.rate;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Rate));
        }

        public void EditEmployee()
        {
            editEmployee.rate = Rate;
            editEmployee.name = Name;
            Shell.Current.GoToAsync("//Employer");
        }


        public Employee editEmployee { get; set; }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
