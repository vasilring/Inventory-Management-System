using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Commands
{
    internal class ChangeProductValueCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3; // ToDo add validations for arguments
        public ChangeProductValueCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowProductById], Product id[1], Choise[name/price/quantity], Value[Cosnobell, 33.00, 1000]

            // Original command form: ShowProductById
            // Parameters:
            //  [0] - product id
            //  [1] - name of the value we want to change: `name, price or quantity`
            //  [2] - the new value

            var id = ParseIntParameter(this.CommandParameters[0], "Id");
            var choise = this.CommandParameters[1];
            object value = this.CommandParameters[2];

            value = choise.ToLower() switch
            {
                "name" => (string)value,

                "price" => ParseDecimalParameter((string)value, "Price"),

                "quantity" => ParseIntParameter((string)value, "Quantity"),

                _ => throw new EntityNotFoundException("Invalid choise parameter"),
            };

            var query = this.Repository.ChangeProductValue(id, choise, value);

            return query.ToString();


        }
    }
}
