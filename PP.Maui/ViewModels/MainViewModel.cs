using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices; //needed for [CallerMemberName]
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
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

        public List<Client> Clients
        { get
            {
                return ClientServices.Current.Clients;
            }
        }

        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
