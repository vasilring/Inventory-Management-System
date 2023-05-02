using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.CreateCommands
{
    public class CreateLipstickCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;
        public CreateLipstickCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            // ToDo validator for expected arguments

            //Input:
            // CommandName[CreateLipstick], Name [Dermacol Lipstick], Brand [Dermacol], Price [10.00], Quantity [100], Inventory [Sky]

            //CreateLipstick, Dermacol Lipstick, Dermacol, 10.00, 100, Sky

            // Original command form: CreateLipstick
            // Parameters:
            //  [0] - name
            //  [1] - brand
            //  [2] - price
            //  [3] - quantity
            //  [4] - inventory in which we need to add the product

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "price"); 
            int quantity = ParseIntParameter(this.CommandParameters[3], "quantity");
            var inventoryName = this.Repository.GetInventoryByName(this.CommandParameters[4]); // Check if inventory exists?

            var lipstick = this.Repository.CreateLipstick(name, brand, price, quantity, inventoryName);

            return lipstick.ToString();

        }
    }
}
