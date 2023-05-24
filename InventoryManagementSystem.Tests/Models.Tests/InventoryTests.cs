
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models;
using System.Drawing;
using System.Text;
using System.Xml.Linq;

namespace InventoryManagementSystem.Tests.Models.Tests
{
    [TestClass]
    public class Constructor_Should_Inventory
    {
        private Inventory inventory;
        private string name = "Sky";

        [TestMethod]
        public void Company_Should_Implement_ICompanyInterface()
        {
            var type = typeof(Inventory);
            var isAssignable = typeof(IInventory).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Company class does not implement ICompany interface!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_Throw_Exception_When_Name_IsNull()
        {
            string? invalidName = null;
            inventory = new Inventory(invalidName);
        }

        [TestMethod]
        public void VerifyName()
        {
            inventory = new Inventory(name);
            Assert.AreEqual(name, this.inventory.Name);
        }

        [TestMethod]

        public void Inventory_Constructor_Should_Print_ToString()
        {
            inventory = new Inventory(name);

            var inv = $"Inventory with name: {name} was created";

            Assert.AreEqual(inventory.ToString(), inv.ToString().TrimEnd());
        }
    }
}
