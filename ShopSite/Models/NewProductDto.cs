using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Models
{
    public class NewProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
    }
}
