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
        public int Id { get; set; }
        public DateTime OpenDate {get; set;}
        public DateTime CloseDate { get; set;}
        public bool Closed { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientID { get; set; }
        public Client Owner { get; set; }

        public Project(int id, DateTime open, string sName, string lName,
            int cID, Client owner) 
        {
            Id= id;
            OpenDate= open; 
            CloseDate= default(DateTime);
            Closed = true;
            ShortName= sName;
            LongName= lName;
            ClientID = cID;
            Owner = owner;
        }

        public Project(string name) 
        {
            LongName = name;
            if (LongName.Length > 10)
                ShortName = LongName.Substring(0,10) + "...";
            else ShortName = name;
        }

        public override string ToString()
        {
            return $"{Id}) {ShortName}";
        }

    } //end class
    
} //end namespace

