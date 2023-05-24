using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models.Product;

namespace InventoryManagementSystem.Tests.Models.Tests
{
    [TestClass]
    public class UserTests
    {

        private User user;
        private Role roleM = Role.Manager;
        private string username = "vasilring";
        private string firstName = "vasil";
        private string lastName = "lyubenov";
        private string password = "cvb123!@#CVBasd";

        [TestMethod]

        [TestInitialize]

        public void Initialize()
        {
            this.user = new User(username, firstName, lastName, password, roleM);
        }

        [TestMethod]
        public void User_Should_Implement_IUserInterface()
        {
            var type = typeof(User);
            var isAssignable = typeof(IUser).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "User class does not implement IUser interface!");
        }

        [TestMethod]

        public void ConfirmValidUsernameAssignment()
        {
            Assert.AreEqual(username, this.user.Username);
        }

        [TestMethod]
        public void VerifyFirstName()
        {
            Assert.AreEqual(firstName, this.user.FirstName);
        }

        [TestMethod]
        public void VerifyLastName()
        {
            Assert.AreEqual(lastName, this.user.LastName);
        }

        [TestMethod]
        public void VerifyPassword()
        {
            Assert.AreEqual(password, this.user.Password);
        }

        [TestMethod]
        public void VerifyRole()
        {
            Assert.AreEqual(roleM, this.user.Role);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void Constructor_Should_Throw_Exception_When_Description_IsTooLong()
        {
            string pass = "Wrong Password";

            _ = new User(username, firstName, lastName, pass, roleM);
        }
    }
}
