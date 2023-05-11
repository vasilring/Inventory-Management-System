using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IList<ICompany> Company { get; }

        IUsers LoggedUser { get; }

        ICompany CreateCompany(string name);

        ICompany GetCompanyByName(string name);

        IUsers CreateUserAndCompany(string username, string firstName, string lastName, string password, string companyName, Role role);

        void AddUser(IUsers user, string companyName);

        void UserExist(string username);

        IUsers GetUser(string username);

        void LogUser(IUsers user);

        void LogOutUser();

        IInventory CreateInventory(string name, string companyName);

        void RemoveInventory(ICompany company, string inventoryName);

        IInventory GetInventoryByName(string name);

        ILipstick CreateLipstick(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        IPerfumes CreatePerfume(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        ICream CreateCream(string name, string brand, string description, decimal price, int quantity, IInventory inventory);

        void RemoveProduct(int id, IInventory inventory);

        IProducts ShowProductById(int id);

        IProducts UpdateProductValue(int id, string choise, object updatedProduct);
    }
}
