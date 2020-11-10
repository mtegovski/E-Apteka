using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class ProductModel
    {
        private List<Medicine> products;
        private MedicineContext db = new MedicineContext();
        public ProductModel()
        {
            products = db.Medicines.ToList();
        }
        public List<Medicine> findAll()
        {
            return this.products;
        }
        public Medicine find(int id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }

    }
}