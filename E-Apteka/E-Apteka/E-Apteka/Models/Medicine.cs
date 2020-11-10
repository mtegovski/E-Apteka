using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        public string Producer { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }

    }
}