using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models.Product
{
    public class Perfumes : Products
    {
        public Perfumes(string name, string brand, decimal price) : base(name, brand, price)
        {
        }
    }
}
