using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Tests.Models.Tests.Products_Tests
{
    [TestClass]
    public class Constructor_Should_Cream
    {
        private Cream product;
        private string name = "Dermacol Cream";
        private string brand = "Dermacol";
        private string description = "Night cream";
        private decimal price = 10.0m;
        private int quantity = 10;
        private int id = 1;

        [TestInitialize]
        public void Initialize()
        {
            product = new Cream(id, name, brand, description, price, quantity);
        }

        [TestMethod]
        public void Cream_Should_Implement_ICreamInterface()
        {
            var type = typeof(Cream);
            var isAssignable = typeof(ICream).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Cream class does not implement ICream interface!");
        }

        [TestMethod]
        public void VerifyId()
        {
            Assert.AreEqual(id, product.Id);
        }

        [TestMethod]
        public void VerifyName()
        {
            Assert.AreEqual(name, product.Name);
        }

        [TestMethod]
        public void VerifyBrand()
        {
            Assert.AreEqual(brand, product.Brand);
        }

        [TestMethod]
        public void VerifyDescription()
        {
            Assert.AreEqual(description, product.Description);
        }

        [TestMethod]
        public void VerifyPrice()
        {
            Assert.AreEqual(price, product.Price);
        }

        [TestMethod]
        public void VerifyQuantity()
        {
            Assert.AreEqual(quantity, product.Quantity);
        }

        [TestMethod]
        public void Cream_Constructor_Should_Print_ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: 'Cream' with Id: '{id}'");
            sb.AppendLine($"Name: '{name}'");
            sb.AppendLine($"Brand: '{brand}'");
            sb.AppendLine($"Description: '{description}'");
            sb.AppendLine($"Price: '{price}'");
            sb.AppendLine($"Quantity: '{quantity}'");

            Assert.AreEqual(product.ToString(), sb.ToString().TrimEnd());
        }
    }
}
