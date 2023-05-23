using InventoryManagementSystem.Core;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Models.Enums;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Tests.Core.Tests
{
    [TestClass]
    public class CommandFactoryTests
    {

        [TestMethod]

        [DataRow("RegisterUser")]
        [DataRow("Login")]
        [DataRow("Logout")]
        [DataRow("CreateInventory")]
        [DataRow("CreateCream")]
        [DataRow("CreatePerfume")]
        [DataRow("CreateLipstick")]
        [DataRow("ChangeProductValue")]
        [DataRow("RemoveProduct")]
        [DataRow("ShowAllUsers")]
        [DataRow("RemoveInventory")]
        [DataRow("ShowInventoryStock")]
        [DataRow("ShowAllCompanies")]
        [DataRow("ShowProductById")]
        [DataRow("ChangePassword")]
        [DataRow("ChangeUsername")]
        [DataRow("BuyProduct")]
        [DataRow("FilterProductsBy")]

        public void Factory_Should_CreateCommand(string commandParameters)
        {
            IRepository repository = new Repository();

            ICommandFactory commandFactory = new CommandFactory(repository);

            commandParameters += ", test, test, test, test, test, test, test, test";

            var command = commandFactory.Create(commandParameters);

            Assert.AreNotEqual(null, command);
        }

        [TestMethod]

        public void Factory_Should_ThrowException_IfCommandIsInvalid()
        {
            IRepository repository = new Repository();

            ICommandFactory commandFactory = new CommandFactory(repository);

            var commandParameters = "test, test, test, test, test, test, test, test, test";

            Assert.ThrowsException<InvalidOperationException>(() => commandFactory.Create(commandParameters));
        }
    }
}
