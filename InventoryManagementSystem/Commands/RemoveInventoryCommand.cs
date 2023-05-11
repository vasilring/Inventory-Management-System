using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    public class RemoveInventoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public RemoveInventoryCommand(IList<string> parameters, IRepository repository)
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
            // CommandName[RemoveInventory], Company name [SkyLife], Inventory name [Sky]

            //RemoveInventory, SkyLife, Sky

            // Original command form: RemoveProduct
            // Parameters:
            //  [0] - id
            //  [1] - Inventory name

            var company = this.Repository.GetCompanyByName(this.CommandParameters[0]);

            var inventoryName = this.CommandParameters[1]; // Check if inventory exists?

            this.Repository.RemoveInventory(company, inventoryName);

            return $"Inventory with name: {inventoryName} was removed";
        }
    }
}
