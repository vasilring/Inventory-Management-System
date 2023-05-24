using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;


namespace InventoryManagementSystem.Commands.ClientCommands
{
    public class BuyProductCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 4;
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
            Helper.ValidateParameters(CommandParameters, ExpectedNumberOfArguments);

            //Input:
            //CommandName[BuyProduct],Brand [Dermacol], Product name[Dermacol Lipstick],Inventory name[Sky], Quantity[30]

            // Original command form: BuyProduct
            // Parameters:
            //  [0] - brand
            //  [1] - product name
            //  [2] - inventory name
            //  [3] - quantity of the product we want to buy

            string brand = CommandParameters[0];

            var productName = CommandParameters[1];

            var inventoryName = Repository.GetInventoryByName(CommandParameters[2]);

            int quantity = ParseIntParameter(CommandParameters[3], "Quantity");

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

            Repository.BuyProductsFromCompany(brand, productName, inventoryName, quantity);

            return $"Successfully bought {quantity} pieces from {productName} product";
        }
    }
}

