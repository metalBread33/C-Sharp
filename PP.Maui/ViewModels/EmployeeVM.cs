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

namespace PP.Maui.ViewModels
{
    [QueryProperty(nameof(ClientID), "ClientID")]

    class EmployeeVM :INotifyPropertyChanged
    {
        public string hello;
        public string Hello
        {
            get
            {
                return hello;
            }

            set
            {
                hello = value;
                NotifyPropertyChanged();
            }

        }

        public Client ClientID { get; set; }

        public ObservableCollection<Client> Clients
        {
            get
            {
                return new ObservableCollection<Client>(ClientServices.Current.Clients);
            }
        }

        public void Delete()
        {
            if (SelectedClient == null)
                return;
            ClientServices.Current.Delete(SelectedClient);
            RefreshView();
        }

        public void Add()
        {
            Shell.Current.GoToAsync("//Add_Client");
            RefreshView();
        }

        public void Edit()
        {
            if (SelectedClient == null)
                return;
            Shell.Current.GoToAsync($"//EditClient?ClientID={SelectedClient.Id}");
        }

        public void ViewProjects()
        {
            if (SelectedClient == null)
                return;
            Shell.Current.GoToAsync($"//ViewClient?ClientID={SelectedClient.Id}");
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged("Clients");
        }

        public Client SelectedClient { get; set; }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
