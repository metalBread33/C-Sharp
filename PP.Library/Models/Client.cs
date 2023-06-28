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
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool Closed { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<Project> Projects { get; set; }

   
        public Client(int id, DateTime open, string name, 
            string notes) 
        {
            Id = id;
            OpenDate = open;
            Name = name;
            Notes = notes;
            Closed = false;
            CloseDate = default(DateTime);
            Projects = new List<Project>();
        }

        public override string ToString()
        {
            return $"{Id+1}) {Name}";
        }
        
        public Client() 
        {
            Projects = new List<Project>();
        }

    }//end class Client
}
