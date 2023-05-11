using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;

namespace InventoryManagementSystem.Core.Contracts
{
    public interface IRepository
    {
        IList<ICompany> Companies { get; }

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

        IInventory GetInventoryByName(string name);

        ILipstick CreateLipstick(string name, string brand, decimal price, int quantity, IInventory inventory);

        IPerfumes CreatePerfume(string name, string brand, decimal price, int quantity, IInventory inventory);

        ICream CreateCream(string name, string brand, decimal price, int quantity, IInventory inventory);

        IProducts ShowProductById(int id);

        // test - it is working
        IProducts ChangeProductValue(int id, string choise, object updatedProduct);
    }
}
