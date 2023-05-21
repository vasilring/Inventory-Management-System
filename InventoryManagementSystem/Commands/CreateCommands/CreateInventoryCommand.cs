using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.CreateCommands
{
    public class CreateInventoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public CreateInventoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            //Input:
            // CommandName[CreateInventory], Inventory name[Sky], Company name [SkyLife]

            // CreateInventory, Sky, SkyLife

            // Original command form: CreateInventory
            // Parameters:
            //  [0] - inventory name
            //  [1] - company name

            string inventoryName = CommandParameters[0];
            string companyName = CommandParameters[1];

            var inventory = Repository.CreateInventory(inventoryName, companyName);

            return inventory.ToString();
        }


    }
}
