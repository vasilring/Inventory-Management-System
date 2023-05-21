using ConsoleTableExt;
using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    internal class BuyProductCommand: BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; // ToDo add validations for arguments
        public BuyProductCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowInventoryStock], Company name[Sky]

            // Original command form: ShowInventoryStock
            // Parameters:
            //  [0] - inventory name

            var productName = this.CommandParameters[0];

            var quantity = ParseIntParameter(this.CommandParameters[1], "Quantity");

            this.Repository.BuyProductsFromCompany(productName, quantity);

            return $"Successfully bought {quantity} pieces from {productName} product";
        }
    }
}

