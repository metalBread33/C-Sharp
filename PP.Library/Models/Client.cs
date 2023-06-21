﻿using System;
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
        public bool Closed { get; set; }
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
            Closed = false;
            CloseDate = default(DateOnly);
            Projects = new List<Project>();
            Projects[0] = new Project (0, DateTime.Now, "test", "test", id, this);
        }

        public override string ToString()
        {
            return $"{Id+1}) {Name}";
        }
        
        public Client() 
        {
            Projects = new List<Project>();
            Projects.Add(new Project(1, DateTime.Now, "test", "test", Id, this));
        }

    }//end class Client
}
