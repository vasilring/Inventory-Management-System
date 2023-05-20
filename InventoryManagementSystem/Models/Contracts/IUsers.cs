using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Models.Contracts
{
    public interface IUsers
    {
        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string Password { get; }

        Role Role { get; }

        IList<IInventory> Inventory { get; }

        void AddInventory(IInventory inventory);

        void RemoveInventory(IInventory inventory);

        public void SetPassword(string newPassword);

    }
}
