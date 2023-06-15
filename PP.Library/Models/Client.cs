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
        public DateOnly OpenDate { get; set; }
        public DateOnly CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<Project> Projects { get; set; }

   
        public Client(int id, DateOnly open, string name, 
            string notes) 
        {
            Id = id;
            OpenDate = open;
            Name = name;
            Notes = notes;
            IsActive = true;
            CloseDate = default(DateOnly);
        }

        public override string ToString()
        {
            return $"{Id+1}) {Name}";
        }
        public Client() { }
        

    }//end class Client
}
