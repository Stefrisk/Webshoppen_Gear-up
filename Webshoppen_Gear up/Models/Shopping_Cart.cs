﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Models;

namespace Webshoppen_Gear_up.Shop
{
    internal class Shopping_Cart
    {
        public int Shopping_CartID { get; set; } // becomes order ID then shopping cart is deleted when payment is complete
        public decimal? CartTotal { get; set; }
        public int CustomerID { get; set; }

        public Shopping_Cart(int customerID)
        {
            CustomerID = customerID;
        }
        public virtual List<ShoppingCartItem> shoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        public static int FindCart(int customerID)
        {
            var db = new GearUpContext();
            var curShoppingCart = db.ShoppingCart.SingleOrDefault(x => x.CustomerID == customerID);
            if (curShoppingCart != null)
            {
                return curShoppingCart.Shopping_CartID;
            }
            else 
            { 
                var cart = new Shopping_Cart(customerID);
                db.ShoppingCart.Add(cart);
                db.SaveChanges();
                return cart.Shopping_CartID;
            }

        }
        public static void itemToCart(int cartID, int productID)
        {
            var db = new GearUpContext(); // connect to database
            var shopItems = db.Items;
            var carts = db.ShoppingCart;
            
            

            var mycart = carts.Include(cart => cart.shoppingCartItems) // finds cart iwth matching ID,  include makes sure related items are loaded 
                .FirstOrDefault(cart => cart.Shopping_CartID == cartID);

            var itemResult = shopItems.FirstOrDefault(product => product.ItemID == productID); // find item


            if (itemResult == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }
            else
            {
                var cartItem = new ShoppingCartItem
                {
                    Shopping_CartID = cartID,     // create new shopping cart item
                    ItemId = itemResult.ItemID
                };
                
                db.Add(cartItem);
                db.SaveChanges();
                Console.WriteLine("Item added!");

            }
            
            
                       
        }
        public static void ShowCart(int cusID)
        {
             var db = new GearUpContext();
            var shoppingCarts = db.ShoppingCart;
            var customers = db.Customers;


            var cartResult = shoppingCarts
                .Include(c => c.shoppingCartItems)   
                .ThenInclude(cartItem => cartItem.Item)  
                .FirstOrDefault(c => c.CustomerID == cusID);
          

            if (cartResult == null)
            {
                Console.WriteLine("No shopping cart found");
                return;
            }

            Console.WriteLine("Your shopping cart: ");
            if (cartResult.shoppingCartItems.Any())
            {
                foreach(var cartItem in cartResult.shoppingCartItems)
                {
                    var item2 = cartItem.Item;
                    Console.WriteLine($"Name:{item2.Name} {item2.MiscInfo}  Color:{item2.Color} Size: {item2.Size} ");
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }

        }

    }
}
