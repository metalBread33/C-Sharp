using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Client
    {
        //Variables
        public int Id { get; set; }
        internal DateTime OpenDate { get; set; }
        internal DateTime CloseDate { get; set; }
        internal bool IsActive { get; set; }
        internal string Name { get; set; }
        internal string Notes { get; set; }

   
        public Client(int id, DateTime open, string name, 
            string notes) 
        {
            Id = id;
            OpenDate = open;
            Name = name;
            Notes = notes;
            IsActive = true;
            CloseDate = default(DateTime);
        }

        public override string ToString()
        {
            return $"{Id+1}) {Name}";
        }
        public Client() { }
        

    }//end class Client
}
