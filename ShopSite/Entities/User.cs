using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public int Age { get; set; }
        public int AdresId { get; set; }
        
        public virtual Adres Adres { get; set; }
        public string Nationality { get; set; }


        public int RoleId { get; set; } = 1;
        public virtual Role Role { get; set; }




    }
}
