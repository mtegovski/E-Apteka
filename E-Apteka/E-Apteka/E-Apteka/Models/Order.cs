using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public string pharmacy { get; set; }
        public List<string> medicines { get; set; }
        public Order()
        {
            medicines = new List<string>();
        }
    }
}