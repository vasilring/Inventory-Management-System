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

        IList<IProducts> Products { get; }

        void AddProduct(IProducts product);

        void RemoveProduct(IProducts product);

        string ToString();
    }
}
