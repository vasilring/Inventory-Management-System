using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands
{
    internal class ChangeProductValueCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1; // ToDo add validations for arguments
        public ChangeProductValueCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowProductById], Product id[1], Choise[name/price/quantity], Value[Cosnobell, 33.00, 1000]

            // Original command form: ShowProductById
            // Parameters:
            //  [0] - product id
            //  [1] - name of the value we want to change: `name, price or quantity`
            //  [2] - the new value

            var id = ParseIntParameter(this.CommandParameters[0], "Id");
            var choise = this.CommandParameters[1];
            object value = this.CommandParameters[2];

            switch (choise.ToLower())
            {
                case "name":
                    value = (string)value;
                    break;
                case "price":
                    value = ParseDecimalParameter((string)value, "Price");
                    break;
                case "quantity":
                    value = ParseIntParameter((string)value, "Quantity");
                    break;
                default:
                    throw new ArgumentException("Invalid choise parameter");
            }

            var query = this.Repository.ChangeProductValue(id, choise, value);

            return query.ToString();


        }
    }
}
