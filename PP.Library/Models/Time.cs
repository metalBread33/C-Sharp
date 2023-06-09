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
        public DateOnly Date { get; set; }
        public string Narrative { get; set; }
        public int EmployeeID { get; set; }
        public int ProjectId { get; set; }
        private Employee employee { get; set; }
        private Project project { get; set; }
    }
}
