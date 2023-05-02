using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    public class Company : ICompany
    {
        private readonly IList<IUsers> users = new List<IUsers>();
        private readonly IList<IInventory> inventory = new List<IInventory>();

        public Company(string name) 
        { 
            this.Name = name;
        }

        public string Name { get; set; }
        public IList<IUsers> Users { get => new List<IUsers>(this.users); }
        public IList<IInventory> Inventory { get => new List<IInventory>(this.inventory); }

        public void AddMember(IUsers member)
        {
            this.users.Add(member);
        }

        public void CreateInventory(IInventory inventory)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventory(IInventory inventory)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(IUsers member)
        {
            throw new NotImplementedException();
        }
    }
}
