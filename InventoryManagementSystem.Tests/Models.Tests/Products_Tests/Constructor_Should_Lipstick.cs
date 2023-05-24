using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Product;
using System.Xml.Linq;
using System.Drawing;
using System.Text;

namespace InventoryManagementSystem.Tests.Models.Tests.Products_Tests
{
    [TestClass]
    public class Constructor_Should_Lipstick
    {
        private Lipstick product;
        private string name = "Dermacol Lipstick";
        private string brand = "Dermacol";
        private string description = "Long-lasting lipstick";
        private decimal price = 10.0m;
        private int quantity = 10;
        private int id = 1;

        [TestInitialize]

        public void Initialize()
        {
            product = new Lipstick(id, name, brand, description, price, quantity);
        }

        [TestMethod]

        public void Lipstick_Should_Implement_ILipstickInterface()
        {
            var type = typeof(Lipstick);
            var isAssignable = typeof(ILipstick).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Lipstick class does not implement IUser interface!");
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

        public void Lipstick_Constructor_Should_Print_ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product: 'Lipstick' with Id: '{id}'");
            sb.AppendLine($"Name: '{name}'");
            sb.AppendLine($"Brand: '{brand}'");
            sb.AppendLine($"Description: '{description}'");
            sb.AppendLine($"Price: '{price}'");
            sb.AppendLine($"Quantity: '{quantity}'");

            Assert.AreEqual(product.ToString(), sb.ToString().TrimEnd());
        }
    }

}

