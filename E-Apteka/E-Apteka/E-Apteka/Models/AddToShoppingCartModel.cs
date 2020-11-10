using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using E_Apteka.Models;

namespace E_Apteka.Models
{
    public class AddToShoppingCartModel
    {
        public int Id { get; set; }
        public ShoppingCart cart { get; set; }
        public int medicineId { get; set; }
        public List<Medicine> inCart { get; set; }
        public AddToShoppingCartModel()
        {
            inCart = new List<Medicine>();
        }
    }
}