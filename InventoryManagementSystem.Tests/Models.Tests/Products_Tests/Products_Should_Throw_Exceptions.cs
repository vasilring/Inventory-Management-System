using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Tests.Models.Tests.Products_Tests
{
    [TestClass]
    public class Cream_Should_Throw_Exception
    {
        private Cream product;

        private int id = 1;
        private string name = "Dermacol Cream";
        private string brand = "Dermacol";
        private string description = "Long-lasting cream";
        private decimal price = 10.0m;
        private int quantity = 10;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_Exception_When_Name_IsTooShort()
        {
            string invalidName = "A";
            product = CreateCreamWithInvalidProperty(name: invalidName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_Exception_When_Brand_IsTooShort()
        {
            string invalidBrand = "D";
            product = CreateCreamWithInvalidProperty(brand: invalidBrand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_Exception_When_Description_IsTooShort()
        {
            string invalidDescription = "Short";
            product = CreateCreamWithInvalidProperty(description: invalidDescription);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_Exception_When_Quantity_IsNegative()
        {
            int invalidQuantity = -10;
            product = CreateCreamWithInvalidProperty(quantity: invalidQuantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_Exception_When_Price_IsNegative()
        {
            decimal invalidPrice = -10.0m;
            product = CreateCreamWithInvalidProperty(price: invalidPrice);
        }

        private Cream CreateCreamWithInvalidProperty(string name = null, string brand = null, string description = null, decimal? price = null, int? quantity = null)
        {
            return new Cream(id, name ?? this.name, brand ?? this.brand, description ?? this.description, price ?? this.price, quantity ?? this.quantity);
        }
    }
}

