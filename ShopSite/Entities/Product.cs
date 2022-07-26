﻿using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
    }
}
