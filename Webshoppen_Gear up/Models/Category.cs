using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshoppen_Gear_up.Models
{
    internal class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }

        public Category() { }
        public Category(string name)
        {
            Name = name; 
        }

        public static void ChangeCat() 
        {
            var db = new GearUpContext();

            Console.WriteLine("enter a category ID: ");
            Int32.TryParse(Console.ReadLine(), out int choice);
            if (choice > 0)
            {
                var result = db.Categories.SingleOrDefault(x => x.CategoryID == choice);
                Console.WriteLine("What would you like to change the name of the category to?");
                string newName = Console.ReadLine();
                if (result != null) 
                {
                    result.Name = newName;
                    db.SaveChanges();
                }
                else { Console.WriteLine("name cannot be null must contain characters"); }

            }
            else { Console.WriteLine("Choice must be greater that 0 and not negative"); }
        } 
        
        public static void AddCat()
        {
            var db = new GearUpContext();
            Console.WriteLine("Enter name of new category:  ");
            string newCat = Console.ReadLine();
            if (newCat != null)
            {
                Category category = new Category(newCat);
                db.Categories.Add(category);
                db.SaveChanges();
            }
            else { Console.WriteLine("Invaild category name! Cannot be null must contain characters!"); }
        }
        public static void RemoveCat() 
        {
            var db = new GearUpContext();

            Console.WriteLine("Enter a category ID: ");
            Int32.TryParse(Console.ReadLine(), out int choice);
            if (choice > 0)
            {
                var result = db.Categories.SingleOrDefault(x => x.CategoryID == choice);
                if (result != null) 
                { 
                    result.IsDeleted = true;
                    db.Categories.Remove(result);
                    db.SaveChanges();
                }
                else { Console.WriteLine("Category not found!"); }
               
            }
            else { Console.WriteLine("Choice must be greater that 0 and not negative"); }
        }
        
    }
}
