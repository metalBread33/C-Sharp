using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Maui.ViewModels
{
    internal class ViewProjVM
    {
        public ViewProjVM(int ProjId, int ClientId)
        {
            proj = ClientServices.Current.GetClientByID(ClientId).Projects[ProjId];
        }

        public string Name
        {
            get
            {
                return proj.LongName;
            }
        }

        public string OpenDate
        {
            get
            {
                return proj.OpenDate.ToLongDateString();
            }
        }

        public string CloseDate
        {
            get 
            {
                return proj.CloseDate.ToLongDateString();
            }
        }

        public string Closed
        {
            get 
            {
                if (proj.Closed)
                    return "Yes";
                else return "No";
            }
        }

        public string Owner
        {
            get 
            {
                return proj.Owner.ToString();
            }
        }

        public ObservableCollection<Bill> Bills
        {
            get 
            {
                return new ObservableCollection<Bill>(proj.Bills);
            }
        }

        public Project proj { get; set; }
    }
}
