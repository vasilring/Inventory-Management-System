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

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            //CommandName[BuyProduct], Product name[Dermacol Lipstick], Quantity[30]

            // Original command form: BuyProduct
            // Parameters:
            //  [0] - product name
            //  [1] - quantity of the product we want to buy


            var productName = this.CommandParameters[0];

            var quantity = ParseIntParameter(this.CommandParameters[1], "Quantity");

            bool opa = true;

            while (opa)
            {
                Console.WriteLine($"You are about to buy {productName}, {quantity} piece's from it. Are you sure you want to continue?\n");
                Console.WriteLine("Press yes or no!");

                string input = Console.ReadLine();

                if (input.ToLower() == "yes") 
                {
                    opa = false;
                }
                else if (input.ToLower() == "no") 
                {
                    opa = false;
                }
            }

            this.Repository.BuyProductsFromCompany(productName, quantity); 

            return $"Successfully bought {quantity} pieces from {productName} product";
        }
    }
}

