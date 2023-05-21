using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Models.Contracts
{
    public interface IUser
    {
        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string Password { get; }

        Role Role { get; }

        IList<IInventory> Inventory { get; }

        void AddInventory(IInventory inventory);

        void RemoveInventory(IInventory inventory);

        void SetPassword(string newPassword);

        void SetUsername(string newUsername);

    }
}
