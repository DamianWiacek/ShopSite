using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Entities
{
    public class Adres
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }

        public virtual User User { get; set; }

    }
}
