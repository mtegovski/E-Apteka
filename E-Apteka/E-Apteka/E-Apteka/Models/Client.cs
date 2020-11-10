using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class Client
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"07[^3]\d{6}",ErrorMessage="Внесовте невалиден телефонски број!")]
        public string Phone { get; set; }
        [Required]
        public City city { get; set; }
    }
}