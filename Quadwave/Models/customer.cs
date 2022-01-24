using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadwave.Models
{
    public class customer
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string country { get; set; }
        public string customer_date { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address{ get; set; }
        public string city{ get; set; }
        public string number { get; set; }
    }
}