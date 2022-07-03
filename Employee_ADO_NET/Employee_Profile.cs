using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_ADO_NET
{
    internal class Employee_Profile
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public DateTime startdate { get; set; }
        public string gender { get; set; }
        public string phone_no { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public decimal basic_pay { get; set; }
        public decimal deductions { get; set; }
        public decimal taxable_pay { get; set; }
        public decimal income_tax { get; set; }
        public decimal net_pay { get; set; }
    }
}
