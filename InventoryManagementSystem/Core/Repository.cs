using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models.Product;

namespace InventoryManagementSystem.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ICompany> companies = new List<ICompany>();                      

        public IList<ICompany> Companies
        {
            get
            {
                var usersCopy = new List<ICompany>(this.companies);
                return usersCopy;
            }
        }
        public IUsers LoggedUser
        {
            get;
            private set;
        }

        //-----------------------------------------------Company Methods-------------------------------------
        public ICompany CreateCompany(string name)
        {
            var company = new Company(name);
            this.companies.Add(company);
            return company;
        }
        // Find the company if it exists
        public ICompany GetCompanyByName(string name)
        {
            var companies = this.companies.FirstOrDefault(companies => companies.Name == name);

            if (companies == null)
            {
                throw new ArgumentException($"Company with name {name} was not found!");
            }

            return companies;

        }
        //-----------------------------------------------User Methods-------------------------------------
        // Create User and Company also in one method
        public IUsers CreateUser(string username, string firstName, string lastName, string password, string companyName, Role role)
        {
            UserExist(username);

            CreateCompany(companyName);

            var company = GetCompanyByName(companyName);

            var member = new Users(username, firstName, lastName, password, role);

            company.AddMember(member);

            return member;
        }

        public void AddUser(IUsers user, string companyName)
        {
            var company = GetCompanyByName(companyName);
            company.AddMember(user);
        }

        // Check if there is an user with the same name
        public void UserExist(string username)
        {
            var user = this.companies.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            if (user != null)
            {
                throw new ArgumentException($"User with the name {user.Username} exists!");
            }
        }

        public IUsers GetUser(string username)
        {
            var user = this.companies.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User with name {username} was not found!");
            }
            return user;
        }

        public void LogUser(IUsers user)
        {
            this.LoggedUser = user;
        }

        public void LogOutUser()
        {
            this.LoggedUser = null;
        }

        //-----------------------------------------------Inventory Methods-------------------------------------

        public IInventory CreateInventory(string inventoryName, string companyName)
        {
            //ToDo validate inventory with the same name doesnt exist

            var company = GetCompanyByName(companyName);

            var inventory = new Inventory(inventoryName);

            company.CreateInventory(inventory);

            return inventory;
        }

        public IInventory GetInventoryByName(string name)
        {
            var inventory = this.companies.SelectMany(p => p.Inventory).FirstOrDefault(p => p.Name == name);

            if (inventory == null)
            {
                throw new ArgumentException($"Board with name {name} was not found!");
            }
            return inventory;
        }

        public ILipstick CreateLipstick(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
            //var nextId = companies.SelectMany(t => t.Boards).SelectMany(t => t.Tasks).Count();

            var lipstick = new Lipstick(name, brand, price, quantity);

            inventory.AddProduct(lipstick);

            return lipstick;
        }

        public IPerfumes CreatePerfume(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
            //var nextId = companies.SelectMany(t => t.Boards).SelectMany(t => t.Tasks).Count();        ID CHECK??

            var perfume = new Perfumes(name, brand, price, quantity);

            inventory.AddProduct(perfume);

            return perfume;
        }

        public ICream CreateCream(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
            //var nextId = companies.SelectMany(t => t.Boards).SelectMany(t => t.Tasks).Count();

            var cream = new Cream(name, brand, price, quantity);

            inventory.AddProduct(cream);

            return cream;
        }
    }
}
