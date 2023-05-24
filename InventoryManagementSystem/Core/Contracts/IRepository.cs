using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IList<ICompany> Company { get; }

        IUser LoggedUser { get; }

        ICompany CreateCompany(string name);

        ICompany GetCompanyByName(string name);

        IUser CreateUserAndCompany(string username, string firstName, string lastName, string password, string companyName, Role role);

        void AddUser(IUser user, string companyName);

        void UserExist(string username);

        IUser GetUser(string username);

        void LogUser(IUser user);

        void LogOutUser();

        void ChangePassword(IUser username, string password);

        void ChangeUsername(IUser user, string newUsername);

        IInventory CreateInventory(string name, string companyName);

        void RemoveInventory(ICompany company, string inventoryName);

        IInventory GetInventoryByName(string name);

        ILipstick CreateLipstick(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        IPerfumes CreatePerfume(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        ICream CreateCream(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        void RemoveProduct(int id, IInventory inventory);

        IProduct ShowProductById(int id);

        void UpdateProductValue(int id, string choise, object updatedProduct);

        // New Buy product commands test
        void BuyProductsFromCompany(string brand, string productName, IInventory inventoryName, int quantity);
    }
}
