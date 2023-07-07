using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal rate { get; set; }
        public List<Time> TimeCard { get; set; }

        public Employee() 
        {
            TimeCard = new List<Time>()
            {
                new Time()
                {
                    Hours=12,
                    employee=this,
                    Date=DateTime.Now,
                    project= new Project("Name") 
                    {
                        Id=1
                    },
                    id =0,
                }
            };

        }

        public override string ToString()
        {
            return $"{id+1}) {name}";
        }
    }
}
