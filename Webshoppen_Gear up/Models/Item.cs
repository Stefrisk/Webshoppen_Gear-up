using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Shop;

namespace Webshoppen_Gear_up.Models
{
    internal class Item
    {
        public int ItemID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public string? MiscInfo { get; set; }
        public int AmountInStock { get; set; }
        public int? OrderQuantity {  get; set; }
        public bool Discount { get; set; }
        public int SuplierID { get; set; }
        public int CategoryID { get; set; }

        
        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual List<Shopping_Cart> Shopping_Carts { get; set; } = new List<Shopping_Cart>();
        
        
         
        public Item() { }
        
        public Item(string name, string size, string color, string gender, string miscInfo, int supplierId, int categoryID, decimal price,int amoutnInStock,bool discount)
        {
            Name = name;
            Size = size;
            Color = color;
            Gender = gender;
            MiscInfo = miscInfo;
            SuplierID = supplierId;
            CategoryID = categoryID;
            Price = price;
            AmountInStock = amoutnInStock;
            Discount = discount;
        }



    }
}
