using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshoppen_Gear_up.Models
{
    internal class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }

        public OrderItem() { }

    }
}
