using InventoryManagementSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    public class ShowInventoryStockCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowInventoryStockCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            //Input:
            //CommandName[ShowInventoryStock], Inventory name[Sky]

            // Original command form: ShowInventoryStock
            // Parameters:
            //  [0] - inventory name


            string inventoryname = this.CommandParameters[0];

            var sb = new StringBuilder();

            sb.AppendLine($"Team: {inventoryname} with Boards: ");

            this.Repository.Companies.SelectMany(x => x.Inventory)
                                .SelectMany(x => x.Products)
                                .ToList()
                                .ForEach(x => sb.AppendLine($"{count++}.{x}").AppendLine());

            return sb.ToString();
        }
    }
}
