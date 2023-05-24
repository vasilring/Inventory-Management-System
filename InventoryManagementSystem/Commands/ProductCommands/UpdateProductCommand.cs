using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Commands.ProductCommands
{
    internal class UpdateProductCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;
        public UpdateProductCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ChangeProductValue], Product id[1], Choise[name/price/quantity], Value[Cosnobell, 33.00, 1000]

            // Original command form: ChangeProductValue
            // Parameters:
            //  [0] - product id
            //  [1] - name of the value we want to change: `name, price or quantity`
            //  [2] - the new value

            var id = ParseIntParameter(CommandParameters[0], "Id");
            var choise = CommandParameters[1];
            object value = CommandParameters[2];

            value = choise.ToLower() switch
            {
                "name" => (string)value,

                "price" => ParseDecimalParameter((string)value, "Price"),

                "quantity" => ParseIntParameter((string)value, "Quantity"),

                _ => throw new EntityNotFoundException("Invalid choise parameter"),
            };

            Repository.UpdateProductValue(id, choise, value);

            if (choise == "name")
            {
                return $"Name of product with {id} was changed to {value}";
            }
            else if (choise == "price")
            {
                return $"Price of product with {id} was changed to {value}";
            }
            else
            {
                return $"Quantity of product with {id} was changed to {value}";
            }


        }
    }
}
