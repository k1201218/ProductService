﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Harjoitus3.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}