using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Maui.ViewModels
{
    internal class EditClientVM : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool Closed { get; set; }

        public EditClientVM(int id) 
        {
            if(id>=0)
                LoadByID(id);
        }

        public Client editClient { get; set; }

        public void LoadByID(int id)
        {
             editClient = ClientServices.Current.GetClientByID(id);

            if (editClient != null)
            {
                Name = editClient.Name;
                Notes = editClient.Notes;
                OpenDate = editClient.OpenDate;
                CloseDate = editClient.CloseDate;
                Closed = editClient.Closed;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));
            NotifyPropertyChanged(nameof(OpenDate));
            NotifyPropertyChanged(nameof(CloseDate));
            NotifyPropertyChanged(nameof(Closed));
            

        }

        public void EditClient()
        {
            editClient.Name= Name;
            editClient.Notes= Notes;
            editClient.OpenDate= OpenDate;
            editClient.CloseDate= CloseDate;
            editClient.Closed= Closed;
            Shell.Current.GoToAsync("//Employee");
        }


        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
