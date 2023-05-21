using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;


namespace InventoryManagementSystem.Commands
{
    internal class BuyProductCommand: BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2; 
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

