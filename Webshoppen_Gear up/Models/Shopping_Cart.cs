using Microsoft.EntityFrameworkCore;
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
        public int Shopping_CartID { get; set; } 
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
                Console.WriteLine("Enter an item quantity: ");
                Int32.TryParse(Console.ReadLine(), out int quantity);
                if (quantity>0&&quantity<itemResult.AmountInStock )
                {
                    var cartItem = new ShoppingCartItem
                    {
                        Shopping_CartID = cartID,     // create new shopping cart item
                        ItemId = itemResult.ItemID,
                        ItemQuantity = quantity
                    };

                    db.Add(cartItem);
                    db.SaveChanges();
                    Console.WriteLine("Item added!");

                }
                else { Console.WriteLine("opps! invaild quantity!"); }
              

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

            Console.WriteLine($"---------------------------------------------------\nYour shopping cart | Cart total: {cartResult.CartTotal} kr");
            if (cartResult.shoppingCartItems.Any())
            {
                foreach (var cartItem in cartResult.shoppingCartItems)
                {
                    var item2 = cartItem.Item;
                    Console.WriteLine($"\nName:{item2.Name} {item2.MiscInfo}  Color:{item2.Color} Size: {item2.Size} Quantity: {cartItem.ItemQuantity} Price: {item2.Price} Item Id: {item2.ItemID}");
                }

                Console.WriteLine("------ Options ------\n1) Remove item\n2) Change quantity\n3) Check out \n4) Exit");
                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        DeleteItem(cartResult.Shopping_CartID);
                        break;
                    case 2:
                        ChangeQuantity(cartResult.Shopping_CartID);
                        break;
                    case 3:
                        Checkout(cusID);
                        break;
                    case 4:
                        return;
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty");
            }

        }
        public static void Checkout(int customerID)
        {
            
            string paymentType = null;
            
            Console.WriteLine("------ Pick a Payment method ------\n1)Card \n2)PayPal \n3)Pick up in store ");
            Int32.TryParse (Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1: paymentType = "Card";
                    break;
                case 2: paymentType = "Paypal";
                    break;
                case 3: paymentType = "Pick up in store";
                    break;

            }
            Console.WriteLine("------ Pick a delivery service ------\n1) Postnord - 58kr \n2) FedEx - 90kr");
            Int32.TryParse(Console.ReadLine(), out int deliveryID);
            if (deliveryID < 3 && deliveryID > 0)
            { 
                decimal shippingCost = 0;
                if (deliveryID == 1 ) shippingCost = 58;
                if (deliveryID == 2) shippingCost = 90;
                
                

                var db = new GearUpContext();
                var myCart = db.ShoppingCart
                    .Include(c => c.shoppingCartItems)
                    .ThenInclude(cartItem => cartItem.Item)
                    .FirstOrDefault(x => x.CustomerID == customerID);
                if (myCart == null)
                {
                    Console.WriteLine("No items in cart!");
                    return;
                }
                Console.WriteLine($"Your total with shipping and taxes: {Decimal.Multiply((decimal)myCart.CartTotal, 0.30m) + shippingCost}kr\n ------ Items: {myCart.CartTotal}kr \n------ Taxes: {Decimal.Multiply((decimal)myCart.CartTotal, 0.30m)}kr \n------ Shipping: {shippingCost}kr");

                var newOrder = new Order
                {
                    CustomerId = customerID,
                    BuyTime = DateTime.Now,
                    BuyDate = DateTime.Now,
                    PaymentType = paymentType,
                    DeliveryId = deliveryID,
                    OrderTotal = Decimal.Multiply((decimal)myCart.CartTotal, 0.30m) + shippingCost
                };
                foreach( var cartItem in myCart.shoppingCartItems)
                {
                    cartItem.Item.AmountInStock = cartItem.Item.AmountInStock - (int)cartItem.ItemQuantity;
                    var orderItem = new OrderItem()
                    {
                        ItemID = cartItem.ItemId,
                        Quantity =cartItem.ItemQuantity,
                        Price = cartItem.Item.Price
                    };
                    newOrder.OrderItems.Add(orderItem);
                }
                db.PreviousOrders.Add(newOrder);
                db.ShoppingCartItem.RemoveRange(myCart.shoppingCartItems);
                db.ShoppingCart.Remove(myCart);
                db.SaveChanges();

                Console.WriteLine("You have been successfuly checked out! Thank you for shopping at GearUp!");

            }
            else { Console.WriteLine("Invaild selection of delivery service"); }
           

        }


        public static void UpdateTotal(int cartID)
        {
            int cartTotal = 0; // each item price in cart is added to this variable...
            var db = new GearUpContext();
            var myCart = db.ShoppingCart;

            var currentCart = myCart.Include(c => c.shoppingCartItems)
                .ThenInclude(cartItem => cartItem.Item)
                .SingleOrDefault(x => x.Shopping_CartID == cartID);

            if (currentCart.shoppingCartItems.Any())
            {
                foreach (var cartItem in currentCart.shoppingCartItems)
                {
                    var item1 = cartItem.Item;
                    cartTotal += Convert.ToInt32(item1.Price);
                }
                currentCart.CartTotal = cartTotal;
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Shopping cart has no items in it.");
            }




        }
        public static void DeleteItem(int currentCartID)
        {
            var db = new GearUpContext();
            var carts = db.ShoppingCart;
            var myCart = carts
                .Include(c => c.shoppingCartItems)
                .ThenInclude(cartItem => cartItem.Item)
                .FirstOrDefault(c => c.Shopping_CartID == currentCartID);
            if (myCart.shoppingCartItems.Any())
            {
                Console.WriteLine("Enter the product ID of item you would like to delete: ");
                if (Int32.TryParse(Console.ReadLine(), out int itemID))
                {

                    var item = myCart.shoppingCartItems.SingleOrDefault(i => i.ItemId == itemID);

                    if (item != null)
                    {
                        myCart.shoppingCartItems.Remove(item);
                        db.SaveChanges();
                        Console.WriteLine("Item removed!");

                    }
                    else { Console.WriteLine("Item not found in cart!"); }

                }
                else { Console.WriteLine("We didnt understand that! Please enter valid item ID"); }
            }
            else { Console.WriteLine("Could not find cart"); }




        }
        public static void ChangeQuantity(int currentCartID)
        {
            var db = new GearUpContext();
            var carts = db.ShoppingCart;
            var myCart = carts
               .Include(c => c.shoppingCartItems)
               .ThenInclude(cartItem => cartItem.Item)
               .FirstOrDefault(c => c.Shopping_CartID == currentCartID);
            {
                if (myCart != null)
                {
                    Console.WriteLine("Enter the product ID: ");
                    if (Int32.TryParse(Console.ReadLine(), out int itemID))
                    {
                        var item = myCart.shoppingCartItems.FirstOrDefault(i => i.ItemId == itemID);

                        if (item != null)
                        {

                            Console.WriteLine($"Current quantity: {item.ItemQuantity}" + "\n Enter new quantity");
                            if (Int32.TryParse(Console.ReadLine(), out int newQuantity) && newQuantity > 0)
                            {
                                if (newQuantity == 0)
                                {
                                    myCart.shoppingCartItems.Remove(item);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    item.ItemQuantity = newQuantity;
                                    db.SaveChanges();
                                    Console.WriteLine("Quantity updated!");
                                }

                            }
                            else { Console.WriteLine("Invaild quantity"); }

                        }
                        else { Console.WriteLine("Item not found in cart!"); }

                    }
                    else { Console.WriteLine("We didnt understand that! Please enter valid item ID"); }
                }

            }
        }
    }
}
