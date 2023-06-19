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
        public DateOnly openDate { get; set; }
        public DateOnly closeDate { get; set; }
        public bool isActive { get; set; }

        public EditClientVM(int id=0) 
        {
            if(id>=0)
                LoadByID(id);
        }

        public Client editClient { get; set; }

        public void LoadByID(int id)
        {
            if (id < 0)
                return;
             editClient = ClientServices.Current.GetClientByID(id);

            if (editClient != null)
            {
                Name = editClient.Name;
                Notes = editClient.Notes;
                openDate = editClient.OpenDate;
                closeDate = editClient.CloseDate;
                isActive = editClient.IsActive;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Notes));
            NotifyPropertyChanged(nameof(openDate));
            NotifyPropertyChanged(nameof(closeDate));
            NotifyPropertyChanged(nameof(isActive));
            

        }

        public void EditClient()
        {
            editClient.Name= Name;
            editClient.Notes= Notes;
            editClient.OpenDate= openDate;
            editClient.CloseDate= closeDate;
            editClient.IsActive= isActive;
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
