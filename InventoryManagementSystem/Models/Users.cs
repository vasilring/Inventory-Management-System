using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class Users : IUsers
    {
        private readonly IList<IProducts> products = new List<IProducts>();
        public Users(string username, string firstName, string lastName, string password, Role role) 
        { 
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
        }

        public IList<IProducts> Products { get => new List<IProducts>(this.products); }

        public string Username { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Password { get; }

        public Role Role { get; }

        public void AddProduct(IProducts product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(IProducts product)
        {
            throw new NotImplementedException();
        }
    }
}
