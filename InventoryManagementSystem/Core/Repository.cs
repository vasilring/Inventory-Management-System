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
        private readonly IList<ICompany> company = new List<ICompany>();                      

        public IList<ICompany> Company
        {
            get => new List<ICompany>(this.company);
        }
        public IUser? LoggedUser
        {
            get;
            private set;
        }

        //-----------------------------------------------User Methods-------------------------------------
        public IUser CreateUserAndCompany(string username, string firstName, string lastName, string password, string companyName, Role role)
        {
            UserExist(username);
            
            var member = new User(username, firstName, lastName, password, role);

            CreateCompany(companyName);

            var company = GetCompanyByName(companyName);

            company.AddMember(member);

            return member;
        }

        public void AddUser(IUser user, string companyName)
        {
            var company = GetCompanyByName(companyName);

            company.AddMember(user);
        }

        public void UserExist(string username)
        {
            var user = this.company.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            if (user != null)
            {
                throw new EntityNotFoundException($"User with the name {user.Username} exists!");
            }
        }

        public IUser GetUser(string username)
        {
            var user = this.company.SelectMany(p => p.Users).FirstOrDefault(p => p.Username == username);

            return user ?? throw new EntityNotFoundException($"User with name {username} was not found!");
        }

        public void LogUser(IUser user)
        {
            this.LoggedUser = user;
        }

        public void LogOutUser()
        {
            this.LoggedUser = null;
        }

        //------------------------------------------------------------------User Password && Username Methods------------------------------------------------

        public void ChangePassword(IUser user, string newPassword)
        {
            if (this.LoggedUser != user) 
            {
                throw new InvalidUserInputException("You cannot change other users passwords");
            }

            user.SetPassword(newPassword);
        }

        public void ChangeUsername(IUser user, string newUsername) // TEST
        {
            if (this.LoggedUser != user)
            {
                throw new InvalidUserInputException("You cannot change other users username");
            }

            user.SetUsername(newUsername);
        }

        //-----------------------------------------------Company Methods-------------------------------------

        public ICompany CreateCompany(string name)
        {
            ValidateCompanyDoesntExist(name);

            var company = new Company(name);

            this.company.Add(company);

            return company;
        }

        public ICompany GetCompanyByName(string name)
        {
            var companies = this.Company.FirstOrDefault(companies => companies.Name == name);

            return companies ?? throw new EntityNotFoundException($"Company with name {name} was not found!");
        }

        private void ValidateCompanyDoesntExist(string name)
        {
            if (this.Company.Any(p => p.Name == name))
            {
                throw new InvalidUserInputException($"Company with the name: {name} exists!");
            }
        }

        //-----------------------------------------------Inventory Methods-------------------------------------

        public IInventory CreateInventory(string inventoryName, string companyName)
        {
            ValidateInventoryDoesntExist(inventoryName);

            var company = GetCompanyByName(companyName);

            var inventory = new Inventory(inventoryName);

            company.CreateInventory(inventory);

            return inventory;
        }

        public IInventory GetInventoryByName(string name)
        {
            var inventory = this.Company.SelectMany(p => p.Inventory).FirstOrDefault(p => p.Name == name);

            return inventory ?? throw new EntityNotFoundException($"Inventory with name {name} was not found!");
        }

        private void ValidateInventoryDoesntExist(string name)
        {
            var inventory = this.Company.SelectMany(p => p.Inventory).FirstOrDefault(p => p.Name == name);

            if (inventory != null)
            {
                throw new InvalidUserInputException($"Inventory with the name: {name} exists!");
            }
        }

        public void RemoveInventory(ICompany company, string inventoryName)
        {
            var inventory = this.Company.SelectMany(p => p.Inventory).FirstOrDefault(p => p.Name == inventoryName) ?? throw new EntityNotFoundException($"The inventory named '{inventoryName}' does not exist.");

            var productsToRemove = inventory.Products.ToList();

            foreach (var product in productsToRemove)  // Note! When we remove the inventory from the company, we also remove all the products from the Inventory of the current company
            {
                inventory.RemoveProduct(product);
            }

            company.RemoveInventory(inventory);
        }

        //-----------------------------------------------Products Methods-------------------------------------
                            //-----------------------------------------------Add Methods-------------------------------------
        public ILipstick CreateLipstick(string name, string brand, string description, decimal price, int quantity, IInventory inventory) // ToDo create one methods for all products that we want to create :)
        {
            ValidateProductDoesntExist(name);

            var nextId = this.Company.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var lipstick = new Lipstick(++nextId, name, brand, description, price, quantity);

            inventory.AddProduct(lipstick);

            return lipstick;
        }

        public IPerfumes CreatePerfume(string name, string brand, string description, decimal price, int quantity, IInventory inventory)
        {
            ValidateProductDoesntExist(name);

            var nextId = this.Company.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var perfume = new Perfumes(++nextId, name, brand, description, price, quantity);

            inventory.AddProduct(perfume);

            return perfume;
        }

        public ICream CreateCream(string name, string brand, string description, decimal price, int quantity, IInventory inventory)
        {
            ValidateProductDoesntExist(name);

            var nextId = this.Company.SelectMany(t => t.Inventory).SelectMany(t => t.Products).Count();

            var cream = new Cream(++nextId, name, brand, description, price, quantity);

            inventory.AddProduct(cream);

            return cream;
        }

        private void ValidateProductDoesntExist(string name)
        {
            var product = this.Company.SelectMany(p => p.Inventory).SelectMany(x => x.Products).FirstOrDefault(p => p.Name == name); // ToDo when we have more users we can let the other users have the same product in their company so this needs to be fixed

            if (product != null)
            {
                throw new InvalidUserInputException($"Product with the name: {name} exists!");
            }
        }

        //-----------------------------------------------Remove Methods-------------------------------------
        public void RemoveProduct(int id, IInventory inventory)
        {
            var product = this.Company
                .SelectMany(c => c.Inventory)
                .SelectMany(c => c.Products)
                .FirstOrDefault(p => p.Id == id) ?? throw new EntityNotFoundException("There is no current porudct with this id");

            inventory.RemoveProduct(product);
        }
                            //-----------------------------------------------Other Product Methods-------------------------------------
        public IProduct ShowProductById(int id)
        {
            var product = this.Company.SelectMany(x => x.Inventory).SelectMany(x => x.Products).FirstOrDefault(x => x.Id == id);

            return product ?? throw new EntityNotFoundException($"No product with ID: {id} was found!");
        }

        public void UpdateProductValue(int id, string choise, object updatedProduct)
        {
            var product = this.Company
                                  .SelectMany(c => c.Inventory)
                                  .SelectMany(i => i.Products)
                                  .OfType<Product>()
                                  .FirstOrDefault(p => p.Id == id)! ?? throw new EntityNotFoundException("Product was not found!");

            switch (choise.ToLower())
            {
                case "name":
                    product.SetName((string)updatedProduct);
                    break;
                case "price":
                    product.SetPrice((decimal)updatedProduct);
                    break;
                case "quantity":
                    product.SetQuantity((int)updatedProduct);
                    break;
                default:
                    throw new EntityNotFoundException("Invalid choise parameter");
            }  
        }


        //---------------------------------- NEW Clients Commands ------------------------------------------

        // Clients can buy product from many companies. When the clients buys products from a company, the inventory of the current company should change.
        // If the clients removes the products from his shopping cart, the inventory of the company from which the products were bought, should change.

        public void BuyProductsFromCompany(string productName, int quantity)
        {
           

            // Find the specific product in the inventory
            var product = this.Company
                                  .SelectMany(c => c.Inventory)
                                  .SelectMany(i => i.Products)
                                  .OfType<Product>()
                                  .FirstOrDefault(p => p.Name == productName);

            if (product != null)
            {
                // Check if there are enough products in the inventory
                if (product.Quantity >= quantity)
                {
                    product.ChangeQuantity(quantity);
                }
                else
                {
                    throw new Exception($"Insufficient quantity of product  {productName} in the inventory.");
                }
            }                                                                                   // ToDo change exceptions
            else
            {
                throw new Exception($"Product {productName} not found in the inventory.");
            }
        }
    }
}
