using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshoppen_Gear_up.Shop;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Webshoppen_Gear_up.Models
{
    internal class GearUpContext : DbContext 
    {   
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> PreviousOrders { get; set; }
        public DbSet<DeliveryService> DeliveryServices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shopping_Cart> ShoppingCart { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = tcp:stefanserver.database.windows.net, 1433; Initial Catalog = StefanGearUp; Persist Security Info = False; User ID = stefrisk; Password = Kansas_1995; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
