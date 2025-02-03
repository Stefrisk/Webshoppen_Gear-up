using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Models;

namespace Webshoppen_Gear_up.Shop
{
    internal class ShopUI
    {


        public static void DrawStart()
        {
            var db = new GearUpContext();
            var shopItems = db.Items;

            var itemresult = shopItems.Where(item => item.Discount == true ).Take(3);
            var discountItems = itemresult.ToList();

            





            List<string> Deal1 = new List<string> { discountItems[0].Name, discountItems[0].Size, discountItems[0].Color, discountItems[0].Price.ToString(),"Press B"};
            Window Fjallraven = new Window("Deal 1", 0, 9, Deal1);
            Fjallraven.Draw();

            List<string> Deal2 = new List<string> { discountItems[1].Name, discountItems[1].Size, discountItems[1].Color, discountItems[1].Price.ToString(),"Press N" };
            Window springSale = new Window("Deal 2!", 33, 9, Deal2);
            springSale.Draw();

            List<string> Deal3 = new List<string> { discountItems[2].Name, discountItems[2].Size, discountItems[2].Color, discountItems[2].Price.ToString(), "Press M"};
            Window clearence = new Window("Deal 3", 66,9,Deal3);
            clearence.Draw();

            List<string> startMenu = new List<string> { "1)Store ","2)My Cart","3)Search(notworkingyet)", "4)Admin, 5) Return to start" };
            Window startpageMenu = new Window("Start",0,18,startMenu);
            startpageMenu.Draw();

           
            var shopCategories = db.Categories;
            var categoryList = from cat in shopCategories
                               select cat;


            Window categoriesWindow = new Window("Categories", 30, 18, Window.CatToString(categoryList));
            categoriesWindow.Draw();

        }
        public static void DrawStoreGender() 
        {
            Console.WriteLine("                                        .-##-.                                         \r\n                                       :##=#%#..                                       \r\n                                    ..+%*..=%%%+..                                     \r\n                                   .=#*:. .+%%%%#-.                                    \r\n                                 :+#=...  ..:--#%%=..:-==.                             \r\n                         .+-. .:*%+..          .+%%%%%%#%%:.                           \r\n                     ..%%%%%%*%#-..          ..+%#=.+:..:#%+..                         \r\n                    .=#-.*%*+%#:            .-*:...     .+%%*:.                        \r\n                  .:**. =#-:#*:.           ....*%*-:.     .#%%=.                       \r\n            ...  .-%+..+*.:+:.               .#%%+..      :%%%%#.                      \r\n           .=%##%#-. .+..... .:*%+..      ..=+.             .:*#%*--=+-...             \r\n          .=#+.:=.   ..    .:*#=-#%+..   .:-..                  .%###%%%*-.            \r\n         .=#.....        .=#%+:.:+%%#+=:.            .==-.    .:+:. .##=-#*.           \r\n        .++.        ...=#%%*.    -%=-+%%%+..       .*%%#%#-. .-..   ... ..*%+.         \r\n      .-*-.    ..-%%##%%%%%%-   ::.  .-#%%%%+:....+%%#-:*%%%%=..         ..+##=..      \r\n    ..+#:.   .:+#*: ..#%=:*+.        .=-..**=+#++%%%#...*%%%%%%+:.          ..+*-.     \r\n   .=%=.   .:+=-.  .-*=.....        .... .....+#*=+%#. ..#%%%%%%%#*+-.        .:+#-.   \r\n .:*+..  .-=..    .::..                   ..+%+...+*..  .*%%#=-%%%%%%%#:.       ..=*-. \r\n.=*:. ..:-.                             .:*#=. ..+-.     .-+. ..#%%+*%%%%+:..      ..+-\r\n=:.                                   .:-..    .:..               .-:...::::.         .");
            List<string> customerOptions = new List<string> { "1)Mens clothing", "2)Womens clothing", "3)Unisex" };
            Window store_startwindow = new Window("Browse our assortment!", 25,10,customerOptions);
            store_startwindow.Draw();
        }

        public static void DrawCategories()
        {
            var db = new GearUpContext();
            var shopCategories = db.Categories;
            var categoryList = from cat in shopCategories
                               select cat;
            

            Window categoriesWindow = new Window("Categories", 15, 2, Window.CatToString(categoryList));
            categoriesWindow.Draw();

        }
        public static int DrawCategories2(int genderChoice, int categoryChoice)
        {
            
            List<string> customerOptions = new List<string> { "Male", "Female", "Unisex" }; // categories hard coded becuase they never change

            var db = new GearUpContext();
            var shopCategories = db.Categories; // connect to database
            var shopItems = db.Items; 

            var result = from item in shopItems
                         where (item.CategoryID == categoryChoice + 1 && item.Gender == customerOptions[genderChoice]) //querey items based on selections
                         select item;
            
            var categoryList  = from cat in shopCategories // querey cats to include appropriate header to window 
                          select cat;

           var categoryStrings = Window.CatToString(categoryList); // to string to make indexing easier
            List<string> itemQ = Window.ItemToString(result);
            int itemChoice = 0;
            if (result.Any())
            {
                Window searchWindow = new Window(categoryStrings[categoryChoice], 1, 2,itemQ );
                searchWindow.Draw();
                try
                {
                    itemChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch { Console.WriteLine("choice did not match any option in the window. Try again."); }

            }
            else { Console.WriteLine("Opps! looks like we dont have any of those. Select another category. Press enter to return to menu."); } // if nothing is found that matches your search you see this message
           

            return itemChoice;










        }

        public static void DrawProductInfo(int productID)
        {
           
            var db = new GearUpContext(); // connect to database
            var shopItems = db.Items;


            var itemResult = from item in shopItems
                             where (item.ItemID == productID) // find product with matching product id 
                             select item;


            if (itemResult.Any())
            {
                foreach (Item item in itemResult)
                {
                    Console.WriteLine($"Brand: {item.Name}");
                    Console.WriteLine($"Size: {item.Size}");
                    Console.WriteLine($"Color: {item.Color}");
                    Console.WriteLine($"Desc: {item.MiscInfo}");
                    Console.WriteLine($"Amount in stock: {item.AmountInStock}");
                    Console.WriteLine($"Price: {item.Price}");
                }

            }
            else { Console.WriteLine("We did not find what you are looking for! Hit enter return to the main menu and try again"); }




        }

    }
}
