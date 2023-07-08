using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Bill
    {
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }
        public Employee employee { get; set; }
        public Project project { get; set; }

        public Bill() { }

        public override string ToString()
        {
            return $"Due {DueDate.ToShortDateString()} Amount Owed: {TotalAmount}";
        }
    }
}
