using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Tests.Models.Tests
{
    [TestClass]
    public class Constructor_Should_Company
    {
        private Company company;
        private string name = "Example Company";

        [TestMethod]
        public void Company_Should_Implement_ICompanyInterface()
        {
            var type = typeof(Company);
            var isAssignable = typeof(ICompany).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Company class does not implement ICompany interface!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_Throw_Exception_When_Name_IsNull()
        {
            string invalidName = null;
            company = new Company(invalidName);
        }

        [TestMethod]
        public void VerifyName()
        {
            company = new Company(name);
            Assert.AreEqual(name, this.company.Name);
        }
    }
}
