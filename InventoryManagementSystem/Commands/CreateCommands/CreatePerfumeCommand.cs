using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.CreateCommands
{
    public class CreatePerfumeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;
        public CreatePerfumeCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            // CommandName[CreateCream], Name [Dermacol Cream], Description [Simple Description] , Brand [Dermacol], Price [10.00], Quantity [100], Inventory [Sky]

            //CreatePerfume, Dermacol Perfume, Dermacol, 10.00, 100, Sky

            // Original command form: CreatePerfume
            // Parameters:
            //  [0] - name
            //  [1] - brand
            //  [2] - description
            //  [3] - price
            //  [4] - quantity
            //  [5] - inventory in which we need to add the product

            string name = this.CommandParameters[0];
            string brand = this.CommandParameters[1];
            string description = this.CommandParameters[2];
            decimal price = ParseDecimalParameter(this.CommandParameters[3], "price");
            int quantity = ParseIntParameter(this.CommandParameters[4], "quantity");
            var inventoryName = this.Repository.GetInventoryByName(this.CommandParameters[5]);

            var perfume = this.Repository.CreatePerfume(name, brand, description, price, quantity, inventoryName);

            return $"Product 'Perfume' with  Id: {perfume.Id} was created";

        }
    }
}
