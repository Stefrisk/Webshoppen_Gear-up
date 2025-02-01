using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Shop;

namespace Webshoppen_Gear_up.Models
{
    internal class ShoppingCartItem
    {
        public int Id { get; set; }
        public int Shopping_CartID { get; set; }
        public int ItemId { get; set; }

        public virtual Shopping_Cart ShoppingCart { get; set; }
        public virtual Item Item { get; set; }
    }
}
