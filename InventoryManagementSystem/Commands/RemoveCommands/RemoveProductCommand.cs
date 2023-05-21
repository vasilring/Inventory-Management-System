using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Contracts;
using InventoryManagementSystem.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.RemoveCommands
{
    public class RemoveProductCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public RemoveProductCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
            Helper.ValidateParameters(CommandParameters, ExpectedNumberOfArguments);

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            //Input:
            // CommandName[RemoveProduct], Id [3], Inventory name [Sky]

            //RemoveProduct, 3, Sky

            // Original command form: RemoveProduct
            // Parameters:
            //  [0] - id
            //  [1] - Inventory name


            int id = ParseIntParameter(CommandParameters[0], "Id");
            var inventoryName = this.Repository.GetInventoryByName(CommandParameters[1]); // Check if inventory exists?

            var removedProduct = inventoryName.Products.FirstOrDefault(p => p.Id == id);

            if (removedProduct != null)
            {
                int removedProductIndex = inventoryName.Products.IndexOf(removedProduct);

                this.Repository.RemoveProduct(id, inventoryName);

                // Decrement the IDs of products after the removed product
                for (int i = removedProductIndex ; i < inventoryName.Products.Count; i++)
                {
                    var product = inventoryName.Products[i];
                    product.ChangeId(product.Id);
                }
            }

            return $"Product with Id: {id} was removed";
        }
    }
}
