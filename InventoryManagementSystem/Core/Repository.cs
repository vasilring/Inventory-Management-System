using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models.Product;
using System.Xml.Linq;

namespace InventoryManagementSystem.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ICompany> companies = new List<ICompany>();                      

        public IList<ICompany> Companies
        {
            get => new List<ICompany>(this.companies);
        }
        public IUsers? LoggedUser
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
        public ICompany GetCompanyByName(string name)
        {
            var companies = this.companies.FirstOrDefault(companies => companies.Name == name);

            return companies ?? throw new EntityNotFoundException($"Company with name {name} was not found!");
        }
        //-----------------------------------------------User Methods-------------------------------------
        public IUsers CreateUserAndCompany(string username, string firstName, string lastName, string password, string companyName, Role role)
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

        public void UserExist(string username)
        {
            var user = this.companies.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            if (user != null)
            {
                throw new EntityNotFoundException($"User with the name {user.Username} exists!");
            }
        }

        public IUsers GetUser(string username)
        {
            var user = this.companies.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            return user ?? throw new EntityNotFoundException($"User with name {username} was not found!");
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
            //ToDo validate inventory with the same name doesnt exist, same goes for other methods that need validation - inventory, company, etc.

            var company = GetCompanyByName(companyName);

            var inventory = new Inventory(inventoryName);

            company.CreateInventory(inventory);

            return inventory;
        }

        public IInventory GetInventoryByName(string name)
        {
            var inventory = this.Companies.SelectMany(p => p.Inventory).FirstOrDefault(p => p.Name == name);

            return inventory == null ? throw new EntityNotFoundException($"Board with name {name} was not found!") : inventory;
        }

        public void RemoveInventory(ICompany company, string inventoryName)
        {
            var inventory = this.Companies.SelectMany(p => p.Inventory).Where(p => p.Name.Equals(inventoryName)).FirstOrDefault();

            var productsToRemove = inventory.Products.ToList();

            foreach (var product in productsToRemove)  // Note! When we remove the inventory from the company, we also remove all the products from the Inventory of the current company
            {
                inventory.RemoveProduct(product);
            }

            company.RemoveInventory(inventory);
        }

        //-----------------------------------------------Products Methods-------------------------------------
                            //-----------------------------------------------Add Methods-------------------------------------
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
                            //-----------------------------------------------Remove Methods-------------------------------------
        public void RemoveProduct(int id, IInventory inventory)
        {
            var product = this.Companies
                .SelectMany(c => c.Inventory)
                .SelectMany(c => c.Products)
                .FirstOrDefault(p => p.Id == id) ?? throw new EntityNotFoundException("There is no current porudct with this id");

            inventory.RemoveProduct(product);
        }
                            //-----------------------------------------------Other Product Methods-------------------------------------
        public IProducts ShowProductById(int id)
        {
            var product = this.Companies.SelectMany(x => x.Inventory).SelectMany(x => x.Products).FirstOrDefault(x => x.Id == id);

            return product ?? throw new EntityNotFoundException($"No product with ID: {id} was found!");
        }

        public IProducts UpdateProductValue(int id, string choise, object updatedProduct)
        {
            Products product = (Products)this.Companies // ToDo think of a way to remove the cast..
                                  .SelectMany(c => c.Inventory)
                                  .SelectMany(i => i.Products)
                                  .FirstOrDefault(p => p.Id == id)! ?? throw new EntityNotFoundException("Product not found.");

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
                    throw new EntityNotFoundException("Invalid choise parameter");
            }

            return product;
        }
    }
}
