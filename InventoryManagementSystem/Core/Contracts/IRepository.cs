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

        IUsers CreateUser(string username, string firstName, string lastName, string password, string companyName, Role role);
        void AddUser(IUsers user, string companyName);
        void UserExist(string username);
        IUsers GetUser(string username);

        void LogUser(IUsers user);

        void LogOutUser();
    }
}
