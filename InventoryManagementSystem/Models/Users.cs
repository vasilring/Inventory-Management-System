using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Users
    {
        private readonly IList<Products> products = new List<Products>();
        public Users(string name) 
        { 

        }

        public string Name { get; set; }
        public IList<Products> Products { get => new List<Products>(this.products); }

    }
}
