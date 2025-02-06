using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Models;

namespace Webshoppen_Gear_up
{
    internal class Admin
    {
        public static void AddProducts()
        {
            var db2 = new GearUpContext();
            var shopitems = db2.Items;
            Console.WriteLine("Please enter the following product info to add a new product: ");
            Console.WriteLine("Product name: ");
            string pName = Console.ReadLine();
            Console.WriteLine("Write product Size: S M L XL ");
            string pSize = Console.ReadLine();
            Console.WriteLine("Write product color: ");
            string pColor = Console.ReadLine();
            Console.WriteLine("Write procut gender: Male or Female");
            string pGender = Console.ReadLine();
            Console.WriteLine("Write short product desc:  ");
            string pDesc = Console.ReadLine();
            Console.WriteLine("Write product price: ");
            Decimal.TryParse(Console.ReadLine(), out decimal price);
            Console.WriteLine("How many do we currently have in stock?: ");
            Int32.TryParse(Console.ReadLine(), out int quantity);
            Console.WriteLine("Does this prodcut have a discount?: Write True or False ");
            bool.TryParse(Console.ReadLine(), out bool discount);
            Console.WriteLine("Choose a supplier: write 1 or 2 ");
            Int32.TryParse(Console.ReadLine(), out int supplier);
            Console.WriteLine("Choose a product category: write 1 2 or 3");
            Int32.TryParse(Console.ReadLine(), out int category);
            try
            {
                Item item = new Item(pName, pSize, pColor, pGender, pDesc, supplier, category, price, quantity, discount);
                db2.Items.Add(item);
                db2.SaveChanges();
            }
            catch { Console.WriteLine("something went wrong please try again."); }


        }
        public static void DeleteProducts()
        {
            var db = new GearUpContext();
            var items = db.Items;
            var shopItems = from item in items
                            select item;
            foreach (var item in shopItems)
            {
                Console.WriteLine($"{item.ItemID}: {item.Name} {item.MiscInfo} Color:{item.Color} Size:{item.Size} Gender:{item.Gender}");
            }
            Console.WriteLine("Write a product number to remove.");
            Int32.TryParse(Console.ReadLine(), out int productID);
            var shopItem = shopItems.FirstOrDefault(product => product.ItemID == productID);
            try
            {
                db.Items.Remove(shopItem);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Did not find your item.");
            }
        }
        public static void EditProduct()
        {
            var db3 = new GearUpContext();
            var items = db3.Items;
            var shopItems = from item in items
                            select item;
            foreach (var item in shopItems)
            {
                Console.WriteLine($"{item.ItemID}: {item.Name} {item.MiscInfo} Color:{item.Color} Size:{item.Size} Gender:{item.Gender} Discount: {item.Discount.ToString()}");
            }
            Console.WriteLine("Write a product number to edit product info.");
            Int32.TryParse(Console.ReadLine(), out int productID);
            var shopItem = shopItems.FirstOrDefault(product => product.ItemID == productID);
            Console.WriteLine($"What would you like to change?: \n 1) Product name \n 2) Discount");
            Int32.TryParse(Console.ReadLine(), out int menuchoice);
            switch (menuchoice)
            {
                case 1:
                    Console.WriteLine("Enter new product name: ");
                    string name = Console.ReadLine();
                    if (name != null)
                    {
                        shopItem.Name = name;
                        db3.SaveChanges();
                    }
                    break;

                case 2:
                    Console.WriteLine("Is product still discounted?: write true or false ");
                    bool.TryParse(Console.ReadLine(), out bool discount);
                    shopItem.Discount = discount;
                    db3.SaveChanges();
                    break;
            }
        }
        public static void SearchProduct()
        {
            Console.WriteLine("Enter the name of the product:  ");
            string name = Console.ReadLine();
            var db = new GearUpContext();
            var items = db.Items;
            var shopItem = items.FirstOrDefault(item => item.Name == name);
            if (shopItem != null)
            {
                Console.WriteLine($"_________________________________________\nFound matching product:\nName:{shopItem.Name}\nDescription:{shopItem.MiscInfo}\nSize:{shopItem.Size}\nColor:{shopItem.Color}\nPrice:{shopItem.Price}Amount in stock:{shopItem.AmountInStock}");
            }
            else
            {
                Console.WriteLine("No item matching your search was found. Try again!");
            }
        }
        public static void EditCats()
        {
            var db = new GearUpContext();
            var categories = db.Categories;
            var myCats = categories.Where(i => (bool)!i.IsDeleted);

            foreach (var cat in myCats)
            {
                Console.WriteLine($"Category Id: {cat.CategoryID} Name: {cat.Name} \n");
            }
            Console.WriteLine($"------ Edit Categories ------\n1) Change name\n 2) Add category\n3) Remove category");
            Int32.TryParse( Console.ReadLine(), out int choice);
            if (choice > 0 && choice < 4)
            {
                switch (choice)
                {
                    case 1:
                        Category.ChangeCat();
                        break;
                    case 2:
                        Category.AddCat();
                        break;
                    case 3:
                        Category.RemoveCat();
                        break;
                }
            }
            else { Console.WriteLine("Invaild menu choice!"); }


        }
    }
}