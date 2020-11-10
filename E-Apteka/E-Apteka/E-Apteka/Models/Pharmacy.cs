using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class Pharmacy
    {
        public string selectedPharmacy { get; set; }
        public virtual List<string> pharmacies { get; set; }

        public Pharmacy()
        {
            pharmacies = new List<string>() { "Zegin", "Eurofarm", "Viafarm" };
        }
    }
}