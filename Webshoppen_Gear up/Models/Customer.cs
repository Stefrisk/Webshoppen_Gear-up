using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Shop;

namespace Webshoppen_Gear_up.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int? OrderID { get; set; }
        public int? ShoppingCartID { get; set; }
         
        


        
        
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        public virtual Shopping_Cart? Shopping_Cart { get; set; }
        
    }
}
