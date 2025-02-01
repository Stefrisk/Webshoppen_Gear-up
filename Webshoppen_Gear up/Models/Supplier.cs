using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshoppen_Gear_up.Models
{
    internal class Supplier
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        

       

        public Supplier() { }
        public Supplier(string name)
        {
            Name = name;
        }
    }
}
