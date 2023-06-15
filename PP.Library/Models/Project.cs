using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Project
    {
        //Variables
        internal int Id { get; set; }
        internal DateTime OpenDate {get; set;}
        internal DateTime CloseDate { get; set;}
        internal bool IsActive { get; set; }
        internal string ShortName { get; set; }
        internal string LongName { get; set; }
        internal int ClientID { get; set; }
        internal Client Owner { get; set; }

        public Project(int id, DateTime open, string sName, string lName,
            int cID, Client owner) 
        {
            Id= id;
            OpenDate= open; 
            CloseDate= default(DateTime);
            IsActive = true;
            ShortName= sName;
            LongName= lName;
            ClientID = cID;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"{Id}) {ShortName}";
        }

    } //end class
    
} //end namespace
