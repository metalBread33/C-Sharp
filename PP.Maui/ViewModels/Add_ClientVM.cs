using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices; //needed for [CallerMemberName]
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PP.Maui.ViewModels
{
    internal class Add_ClientVM : INotifyPropertyChanged
    {

        public string Name { get; set; }
        public string Notes { get; set; }
        public int ID { get; set; }
        public DateOnly openDate { get; set; }
        public DateOnly closeDate { get; set; }
        public bool isActive { get; set; }


        public Add_ClientVM (int id=0)
        {
            if (id>0)
                LoadByID(id);
        }

        public void LoadByID(int id)
        {
            if (id == 0)
                return;
            Client client = ClientServices.Current.GetClientByID(id);

            if(client != null)
            {
                Name = client.Name;
                Notes = client.Notes;
                openDate= client.OpenDate;
                closeDate= client.CloseDate;
                isActive= client.IsActive;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));

        }

        public void AddClient()
        {
            if(ID == 0)
                ClientServices.Current.Add(new Client { Name = Name, Notes=Notes, Id=ClientServices.Current.Clients.Count });
            Shell.Current.GoToAsync("//MainPage");
        }

        public void RefreshView ()
        {
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
