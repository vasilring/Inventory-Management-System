﻿using InventoryManagementSystem.Core.Contracts;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Exceptions;
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

        }
        protected override bool RequireLogin
        {
            get { return true; }
        }
        protected override string ExecuteCommand()
        {
            Helper.ValidateParameters(this.CommandParameters, ExpectedNumberOfArguments);

            //Input:
            // CommandName[RemoveProduct], Id [3], Inventory name [Sky]

            //RemoveProduct, 3, Sky

            // Original command form: RemoveProduct
            // Parameters:
            //  [0] - id
            //  [1] - Inventory name


            int id = ParseIntParameter(CommandParameters[0], "Id");
            var inventoryName = this.Repository.GetInventoryByName(CommandParameters[1]); // ToDo decrement all id's in all inventories, when removing product

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

                return $"Product with ID: {id} has been successfully removed. The IDs of other products have been adjusted.";

            }
            else
            {
                throw new InvalidUserInputException($"Product with ID: {id} was not found.");
            }
        }
    }
}
