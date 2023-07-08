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
    internal class Add_ClientVM
    {

        public string Name { get; set; }
        public string Notes { get; set; }
        public int ID { get; set; }


        public Add_ClientVM()
        {
        }

        public void AddClient()
        {
            ClientServices.Current.Add(new Client
            {
                Id = ClientServices.Current.Clients.Count,
                OpenDate = DateTime.Now,
                CloseDate = DateTime.Now,
                Name = Name,
                Notes = Notes,
                Closed = false,
                Bills = new List<Bill>()
            }) ;
        }

    }
}
