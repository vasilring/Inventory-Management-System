using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.RemoveCommands
{
    public class RemoveInventoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public RemoveInventoryCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            Helper.ValidateParameters(CommandParameters, ExpectedNumberOfArguments);

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
            //  [0] - Company name
            //  [1] - Inventory name

            var company = Repository.GetCompanyByName(CommandParameters[0]);

            var inventoryName = CommandParameters[1];

            Repository.RemoveInventory(company, inventoryName);

            return $"Inventory with name: {inventoryName} was removed";
        }
    }
}
