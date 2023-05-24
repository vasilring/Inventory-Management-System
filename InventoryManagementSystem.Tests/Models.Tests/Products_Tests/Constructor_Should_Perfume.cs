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
    public class Constructor_Should_Perfume
    {
        private Perfumes product;
        private string name = "Dermacol Perfume";
        private string brand = "Dermacol";
        private string description = "Long-lasting perfume";
        private decimal price = 10.0m;
        private int quantity = 10;
        private int id = 1;

        [TestInitialize]
        public void Initialize()
        {
            product = new Perfumes(id, name, brand, description, price, quantity);
        }

        [TestMethod]
        public void Perfume_Should_Implement_IPerfumeInterface()
        {
            var type = typeof(Perfumes);
            var isAssignable = typeof(IPerfumes).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Perfume class does not implement IPerfume interface!");
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
        public void Perfume_Constructor_Should_Print_ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: 'Perfumes' with Id: '{id}'");
            sb.AppendLine($"Name: '{name}'");
            sb.AppendLine($"Brand: '{brand}'");
            sb.AppendLine($"Description: '{description}'");
            sb.AppendLine($"Price: '{price}'");
            sb.AppendLine($"Quantity: '{quantity}'");

            Assert.AreEqual(product.ToString(), sb.ToString().TrimEnd());
        }
    }
}
