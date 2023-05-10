using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models.Product;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ICompany> companies = new List<ICompany>();                      

        public IList<ICompany> Companies
        {
            get => new List<ICompany>(this.companies);

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

            return inventory ?? throw new ArgumentException($"Board with name {name} was not found!");   
        }

        //-----------------------------------------------Products Methods-------------------------------------


        public ILipstick CreateLipstick(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
            var nextId = this.Companies.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var lipstick = new Lipstick(++nextId, name, brand, price, quantity);

            inventory.AddProduct(lipstick);

            return lipstick;
        }

        public IPerfumes CreatePerfume(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
     
            var nextId = this.Companies.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var perfume = new Perfumes(++nextId, name, brand, price, quantity);

            inventory.AddProduct(perfume);

            return perfume;
        }

        public ICream CreateCream(string name, string brand, decimal price, int quantity, IInventory inventory)
        {
            var nextId = this.Companies.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var cream = new Cream(++nextId, name, brand, price, quantity);

            inventory.AddProduct(cream);

            return cream;
        }

        public IProducts ShowProductById(int id)
        {
            var product = this.Companies.SelectMany(x => x.Inventory).SelectMany(x => x.Products).FirstOrDefault(x => x.Id == id);

            return product ?? throw new ArgumentException($"No product with ID: {id} was found!");
        }

        // Testing

        public IProducts ChangeProductValue (int id, string choise, object updatedProduct)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

            Products product = (Products)companies
                                  .SelectMany(c => c.Inventory)
                                  .SelectMany(i => i.Products)
                                  .FirstOrDefault(p => p.Id == id);

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            switch (choise.ToLower())
            {
                case "name":
                    product.Name = (string)updatedProduct;
                    break;
                case "price":
                    product.Price = (decimal)updatedProduct;
                    break;
                case "quantity":
                    product.Quantity = (int)updatedProduct;
                    break;
                default:
                    throw new ArgumentException("Invalid choise parameter");
            }

            return product;
        }
    }
}
