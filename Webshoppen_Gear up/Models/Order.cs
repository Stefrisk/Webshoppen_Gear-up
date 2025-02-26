﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshoppen_Gear_up.Models
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int? ItemQuantity { get; set; }
        public decimal? OrderTotal { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime BuyTime { get; set; }
        public string PaymentType { get; set; }

        public int CustomerId { get; set; }
        public int? DeliveryId { get; set; }
        public int? ItemId { get; set; }

        public Order() { }


        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Item>? Items { get; set; } = new List<Item>();
        public virtual Customer? Customer { get; set; }
        public virtual DeliveryService? DeliveryService { get; set; }

        public static void AllOrders()
        {
            var db = new GearUpContext();
            var orderList = from cat in db.PreviousOrders
                            select cat;
            foreach (var order in orderList)
            {
                Console.WriteLine($"Order Id: {order.OrderID} Order Total: {order.OrderTotal} Buy Date and time: {order.BuyDate} Payment type: {order.PaymentType} Customer ID : {order.CustomerId} ");
            }
            Console.ReadLine();
        }
    }    
}
