using Microsoft.Maui.Controls;
using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Maui.ViewModels
{
    internal class ViewClientVM : INotifyPropertyChanged
    {
        public ViewClientVM(int id)
        {
            SelectedClient = ClientServices.Current.GetClientByID(id);
        }

        public Client SelectedClient { get; set; }
        public Project SelectedProject { get; set; }
        public ObservableCollection<Project> Projects 
        { 
            get
            {
                return new ObservableCollection<Project>(ClientServices.Current.Clients[SelectedClient.Id].Projects);
            }
        }

        public string Name
        {
            get
            {
                return SelectedClient.Name;
            }
        }

        public string Notes
        {
            get { return SelectedClient.Notes; }
        }

        public string OpenDate
        {
            get
            {
                return  SelectedClient.OpenDate.ToShortDateString();
            }
        }

        public string CloseDate
        {
            get
            {
                return SelectedClient.CloseDate.ToShortDateString();
            }
        }

        public string Closed
        {
            get
            {
                if (SelectedClient.Closed)
                    return "Yes";
                else return "No";
            }
        }

        public void Delete()
        {
            if (SelectedProject == null)
                return;
            ClientServices.Current.Clients[SelectedClient.Id].Projects.Remove(SelectedProject);
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged("Projects");
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
