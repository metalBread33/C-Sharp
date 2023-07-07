using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PP.Library.Models;
using PP.Library.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PP.Maui.ViewModels
{
    internal class AddTimeVM : INotifyPropertyChanged
    {
        public AddTimeVM(int EmpId)
        {
            employee = EmployeeServices.Current.GetEmployeeByID(EmpId);
        }

        public int HoursWorked { get; set; }
        public Employee employee { get; set; }
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public Project SelectedProj { get; set; }

        public ObservableCollection<Project> Projects
        {
            get
            {
                 return new ObservableCollection<Project>(GetAllProjects());
            }
        }

        public List<Project> GetAllProjects ()
        {
            List<Project> result = new List<Project>();
            foreach (Client client in ClientServices.Current.Clients)
            {
                foreach (Project project in client.Projects) 
                {
                    result.Add(project);
                }
            }
            return result;
        }

        public void Add()
        {
            employee.TimeCard.Add(
                new Time
                { 
                    client = SelectedProj.Owner,
                    project = SelectedProj,
                    Hours = HoursWorked,
                    Date = Date,
                    employee = employee,
                    EmployeeID = employee.id,
                    Narrative = Narrative,
                    ProjectId = SelectedProj.Id,
                    id = employee.TimeCard.Count
                }
                );
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
