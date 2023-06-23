using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PP.Maui.ViewModels
{

    internal class AddProjVM 
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int ClientID { get; set; }
        public Client Owner { get; set; }

        public void Add()
        {
            Owner.Projects.Add
                (
                new Project (Name)
                {
                    Owner = Owner,
                    ClientID = ClientID,
                    LongName = Name,
                    Closed = false,
                    OpenDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Id = Owner.Projects.Count
                }
                );
        }

        public AddProjVM(int id) 
        { 
            
            ClientID = id;
            Owner = ClientServices.Current.GetClientByID(ClientID);

        }

    }
}
