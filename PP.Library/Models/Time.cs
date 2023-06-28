using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Time
    {
        public int Hours { get; set; }
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectId { get; set; }
        public Employee employee { get; set; }
        public Project project { get; set; }

        public Time()
        {

        }

        public override string ToString()
        {
            return $"Date: {Date} Hours:{Hours}" +
                $"Project Info {project}";
        }
    }
}
