using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Shop;

namespace Webshoppen_Gear_up.Models
{
    internal class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string StreetAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int? OrderID { get; set; }
        public int? ShoppingCartID { get; set; }

        public Customer() { }

        public Customer(string name, int age, string country, string city, int postalcode, string streetaddress, string email, int phone)
        {
            Name = name;
            Age = age;
            Country = country;
            City = city;
            PostalCode = postalcode;
            StreetAddress = streetaddress;
            Email = email;
            Phone = phone;

        }
        
        
        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
        public virtual Shopping_Cart? Shopping_Cart { get; set; }


        public static void NewCustomer()
        {
            Console.WriteLine("---------------------------------------------------------------------------------\nCreate new customer | Please enter the following information: ");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Country:");
            string country = Console.ReadLine();
            Console.WriteLine("City:");
            string city = Console.ReadLine();
            Console.WriteLine("Postalcode:");
            int postal = int.Parse(Console.ReadLine());
            Console.WriteLine("Street Address:");
            string street = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Phone number:");
            int phone = int.Parse(Console.ReadLine());

            try
            {
                Customer newCustomer = new Customer(name, age, country, city, postal, street, email, phone);
                var db = new GearUpContext();
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Something when wrong, please try again.");
                
            }

        }

        public static int FindCustomer()
        {
            while (true)
            {
                Console.WriteLine("Enter your name: ");
                string customer = Console.ReadLine();
                var db = new GearUpContext();
                var result = db.Customers.SingleOrDefault(x => x.Name == customer);
                if (result != null)
                {
                    return result.CustomerID;
                }
                else
                {
                    Console.WriteLine("Could not find customer, try again");
                    
                }
            }
                
        }

       

        
    }
}
