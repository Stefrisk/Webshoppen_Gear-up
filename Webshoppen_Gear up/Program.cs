using System.ComponentModel;
using Webshoppen_Gear_up.Models;
using Webshoppen_Gear_up.Shop;

namespace Webshoppen_Gear_up
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while(true)
            {
                Shopping_Cart cart = new Shopping_Cart();
                Console.Clear();
                Console.WriteLine("  ____  ____  ____  ____  ____    ____                 _   _         ____  ____  ____  ____  ____  \r\n /\\   \\/\\   \\/\\   \\/\\   \\/\\   \\  / ___| ___  __ _ _ __| | | |_ __   /\\   \\/\\   \\/\\   \\/\\   \\/\\   \\ \r\n/  \\___\\ \\___\\ \\___\\ \\___\\ \\___\\| |  _ / _ \\/ _` | '__| | | | '_ \\ /  \\___\\ \\___\\ \\___\\ \\___\\ \\___\\\r\n\\  /   / /   / /   / /   / /   /| |_| |  __/ (_| | |  | |_| | |_) |\\  /   / /   / /   / /   / /   /\r\n \\/___/\\/___/\\/___/\\/___/\\/___/  \\____|\\___|\\__,_|_|   \\___/| .__/  \\/___/\\/___/\\/___/\\/___/\\/___/ \r\n                                                            |_|                                    ");
                Console.WriteLine();

                Console.WriteLine("                       Is it time to gear up for your next adventure?! We got you! ");
                ShopUI.DrawStart();

                Console.WriteLine("Enter a menu option from start window: ");
                Int32.TryParse(Console.ReadLine(), out int choice);
                
                switch (choice)
                {
                    case 1: // shop by category
                        Console.Clear();                         
                        ShopUI.DrawStoreGender();
                        Int32.TryParse(Console.ReadLine(), out int genderchoice1);
                        Console.Clear();
                        ShopUI.DrawCategories();
                        Int32.TryParse(Console.ReadLine(), out int categorychoice);
                        Console.Clear();
                        Console.WriteLine("Write an item number to see more info.");
                        int productID = ShopUI.DrawCategories2(genderchoice1-1,categorychoice-1);
                        ShopUI.DrawProductInfo(productID);
                        Console.WriteLine("Press 1 to add to cart\nPress 2 to return to main menu ");
                        Int32.TryParse(Console.ReadLine(), out int buyOrReturnmenu);
                        switch (buyOrReturnmenu)
                        {
                            case 1:
                                
                                Shopping_Cart.itemToCart(cart, productID);
                                
                                break;
                            
                            case 2:
                                break;
                        }




                        break;
                    
                    case 2:
                        Console.WriteLine("Please enter your Customer ID number: ");
                        Int32.TryParse(Console.ReadLine(), out int customerID);
                        cart.CustomerID = customerID;
                        Shopping_Cart.ShowCart(customerID);
                        Console.ReadLine();     
                        break;
                   
                    case 3: // free search 
                        break;

                    case 4: //Admin 
                        Console.WriteLine("1)Edit product \n2) Edit category \n3)Edit customer");
                        Int32.TryParse(Console.ReadLine(), out int adminchoice);
                        switch (adminchoice)
                        {
                            case 1 : // edit product 
                                Console.WriteLine("1) Add \n2) Delete\n3) Change");
                                Int32.TryParse(Console.ReadLine(), out int adminproduct);
                                switch (adminproduct)
                                {
                                    case 1 :
                                        Admin.AddProducts();
                                        break;
                                    case 2 : Admin.DeleteProducts();
                                        break;
                                    case 3: Admin.EditProduct();
                                        break;
                                }
                                break;
                            case 2 :// edit category

                                break;
                            case 3 :// edit Customer

                                break;

                        }


                        break;


                }
                Console.ReadLine();
            }


            
        }
    }
    
}
