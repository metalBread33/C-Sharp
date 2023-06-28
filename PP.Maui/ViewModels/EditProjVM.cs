using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Maui.ViewModels
{
    class EditProjVM : INotifyPropertyChanged
    {
        public EditProjVM(int ProjId, int ClientId)
        {
            proj = ClientServices.Current.GetClientByID(ClientId).Projects[ProjId];

        }

        public void EditProj()
        {
            proj.LongName = ProjName;
            if (ProjName.Length > 10)
                proj.ShortName = ProjName.Substring(0, 10) + "...";
            else proj.ShortName = ProjName;
            proj.OpenDate = OpenDate;
            proj.CloseDate = CloseDate;
            proj.Closed= Closed;
        }

        public void Back()
        {
            Shell.Current.GoToAsync($"//ViewClient?ClientID={ClientID}");
        }

        public void FlipClosed()
        {
            Closed = !Closed;
        }

        public void Refresh()
        {
            NotifyPropertyChanged("ProjName");
            NotifyPropertyChanged("ProjNotes");
            NotifyPropertyChanged("OpenDate");
            NotifyPropertyChanged("Closed");
            NotifyPropertyChanged("CloseDate");
        }

        public int ProjID { get; set; }
        public int ClientID { get; set; }
        public string ProjName
        {
            get
            {
                return proj.LongName;
            }
            set { }
        }
        public DateTime OpenDate 
        { 
            get
            {
                return proj.OpenDate;
            }
            set { }
        }
        public DateTime CloseDate
        { 
            get
            {
                return proj.CloseDate;
            }
            set { }
        }
        public bool Closed 
        { 
            get
            {
                return proj.Closed;
            }
            set { }
        }
        private Project proj { get; set; }


        /*This make INotifyPropertyChange works*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
