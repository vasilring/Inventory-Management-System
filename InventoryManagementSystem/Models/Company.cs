using InventoryManagementSystem.Models.Contracts;

namespace InventoryManagementSystem.Models
{
    public class Company : ICompany
    {
        private readonly IList<IUser> users = new List<IUser>();
        private readonly IList<IInventory> inventory = new List<IInventory>();

        public Company(string name) 
        { 
            this.Name = name;
        }

        public string Name { get; set; }
        public IList<IUser> Users { get => new List<IUser>(this.users); }
        public IList<IInventory> Inventory { get => new List<IInventory>(this.inventory); }

        public void AddMember(IUser member)
        {
            this.users.Add(member);
        }

        public void RemoveMember(IUser member)
        {
            this.users.Remove(member);
        }

        public void CreateInventory(IInventory inventory)
        {
            this.inventory.Add(inventory);
        }

        public void RemoveInventory(IInventory inventory)
        {
            this.inventory.Remove(inventory);     
        }
    }
}
