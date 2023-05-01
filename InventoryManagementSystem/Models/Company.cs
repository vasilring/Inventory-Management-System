using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Company : ICompany
    {
        private readonly IList<Users> users = new List<Users>();
        private readonly IList<Inventory> inventory = new List<Inventory>();

        public Company(string name) 
        { 
            this.Name = name;
        }

        public string Name { get; set; }
        public IList<Users> Users { get => new List<Users>(this.users); }
        public IList<Inventory> Inventory { get => new List<Inventory>(this.inventory); }

        public void AddMember(Users member)
        {
            throw new NotImplementedException();
        }

        public void CreateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(Users member)
        {
            throw new NotImplementedException();
        }
    }
}
