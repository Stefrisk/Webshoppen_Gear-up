using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshoppen_Gear_up.Models
{
    internal class Order
    {
        public int OrderID { get; set; } //cart ID becomes order id when payment is finished 
        // method that reads entirty of list and find total price, then assigns to field - OrderTotal stored proceedure?
        //public List<Item> OrderItemAssortment{ get; set; }
        public int ItemQuantity { get; set; }
        public float OrderTotal { get; set; }
        public DateTime BuyDate { get; set; }
        public  DateTime BuyTime { get; set; }
        public string PaymentType { get; set; }
        
        public int CustomerId { get; set; }
        public int? DeliveryId { get; set; }
        public int? ItemId { get; set; } 
        


        public virtual ICollection<Item>? Items { get; set; } = new List<Item>();         
        public virtual Customer? Customer { get; set; }
        public virtual DeliveryService? DeliveryService { get; set; }
        

    }
}
