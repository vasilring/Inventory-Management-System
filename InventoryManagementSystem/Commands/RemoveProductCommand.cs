using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    public class RemoveProductCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public RemoveProductCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            // ToDo validator for expected arguments

            //Input:
            // CommandName[RemoveProduct], Id [3], Inventory name [Sky]

            //RemoveProduct, 3, Sky

            // Original command form: RemoveProduct
            // Parameters:
            //  [0] - id
            //  [1] - Inventory name


            int id = ParseIntParameter(this.CommandParameters[0], "Id");

            var inventoryName = this.Repository.GetInventoryByName(this.CommandParameters[1]); // Check if inventory exists?

            this.Repository.RemoveProduct(id, inventoryName);

            return $"Product with Id: {id} was removed";
        }
    }
}
