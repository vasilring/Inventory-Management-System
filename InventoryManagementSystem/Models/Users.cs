using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Models
{
    public class Users : IUsers
    {
        private readonly IList<IInventory> inventory = new List<IInventory>();
        public Users(string username, string firstName, string lastName, string password, Role role) 
        { 
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
        }

        public IList<IInventory> Inventory { get => new List<IInventory>(this.inventory); }

        public string Username { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Password { get; private set; }

        public Role Role { get; }

        public void AddInventory(IInventory inventory)
        {
            this.inventory.Add(inventory);
        }

        public void RemoveInventory(IInventory inventory)
        {
            this.inventory.Remove(inventory);
        }
        public void SetPassword(string newPassword)
        {
            this.Password = newPassword;
        }
    }
}
