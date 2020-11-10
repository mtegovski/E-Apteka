using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace E_Apteka.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string Medicine { get; set; }
        public int OrderId { get; set; }
        public string Pharmacy { get; set; }

    }
}