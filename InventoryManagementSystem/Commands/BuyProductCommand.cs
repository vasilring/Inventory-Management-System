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
            //CommandName[BuyProduct], Product name[Dermacol Lipstick], Quantity[30]

            // Original command form: BuyProduct
            // Parameters:
            //  [0] - product name
            //  [1] - quantity of the product we want to buy

            var productName = this.CommandParameters[0];

            var quantity = ParseIntParameter(this.CommandParameters[1], "Quantity");

            this.Repository.BuyProductsFromCompany(productName, quantity); // ToDo add validation that we cannot buy negative quantity :)

            return $"Successfully bought {quantity} pieces from {productName} product";
        }
    }
}

