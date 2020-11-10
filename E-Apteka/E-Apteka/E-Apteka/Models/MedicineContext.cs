using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace E_Apteka.Models
{
    public class MedicineContext:DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<OrderItem> Orders { get; set; }

        public MedicineContext() : base("DefaultConnection")
        {

        }

    }
}