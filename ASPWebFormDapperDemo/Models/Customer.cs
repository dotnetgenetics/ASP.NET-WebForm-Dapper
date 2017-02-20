using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPWebFormDapperDemo.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DateTime IntroDate { get; set; }

        public decimal CreditLimit { get; set; }
    }
}