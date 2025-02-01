using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Models;

namespace Webshoppen_Gear_up
{
    internal class ItemCreation
    {
        //public static void FillInventory()
        //{
        //    //Creates an amount of any type of item randomly selects property values from below arrays and adds to DB.Items
        //    var db = new GearUpContext();
        //    var paymentTypeList = db.Items;


        //    var jeanMiscInfo = new[] { "Stretch", "Wool", "Light", "Cotton", "PolyBlend", "Ankel", "Knee" };
        //    var jeanSizes = new[] { "28-34", "36-40", "40-46" };
        //    var brandNames = new[] { "LlBean", "Mammut", "SpiderX", "HellyHansen", "RevolutionRace", "Fjällräven", "Arc'teryx", "The North Face", "Khul", "Merrell", "Peli", "Rab", "Sea to Summit", "G3", };
        //    var jeanColors = new[] { "Blue", "Green", "Black", "Grey" };
        //    var jeansGender = new[] { "Male", "Female" };
        //    var jeanPrices = new decimal[50];
        //    var jeanRndInv = new int[50];



        //    for (int i = 0; i < 49; i++)
        //    {
        //        Random rnd = new Random();
        //        int stock = rnd.Next(2, 40); // fill with amountinstock int - inventory 
        //    }

        //    for (int i = 0; i <= 49; i++)
        //    {
        //        Random rnd = new Random();
        //        decimal rndPrice = rnd.Next(200, 800);  //fill prices in int array - price 
        //        decimal price2 = rndPrice;
        //        jeanPrices[i] = price2;

        //    }
        //    for (int i = 0; i <= 49; i++)
        //    {
        //        Random rnd = new Random();

        //        int rndInfo = rnd.Next(0, jeanMiscInfo.Length);
        //        string info = jeanMiscInfo[rndInfo];

        //        int rndName = rnd.Next(0, brandNames.Length);
        //        string name = brandNames[rndName];

        //        int rndSize = rnd.Next(0, jeanSizes.Length);  //creates 50 combinations of jean item 
        //        string size = jeanSizes[rndSize];

        //        int rndColor = rnd.Next(0, jeanColors.Length);
        //        string color = jeanColors[rndColor];

        //        int rndGender = rnd.Next(0, jeansGender.Length);
        //        string gender = jeansGender[rndGender];

        //        int supplier = rnd.Next(2, 6);



        //        DateTime now = DateTime.Now;


        //        Item item = new(name, size, color, gender, info, supplier, 10, jeanPrices[i], jeanRndInv[i]);

        //        db.Items.Add(item);
        //        db.SaveChanges();
        //    }
        //}
    }
}
