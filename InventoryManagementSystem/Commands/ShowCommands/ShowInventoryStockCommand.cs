﻿using InventoryManagementSystem.Core.Contracts;
using System.Data;
using System.Text;
using ConsoleTableExt;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Core.Validations;
using InventoryManagementSystem.Models.Product;
using InventoryManagementSystem.Exceptions;

namespace InventoryManagementSystem.Commands.ShowCommands
{
    public class ShowInventoryStockCommand : BaseCommand
    {
        int cream = 0;
        int perfume = 0;
        int lipstick = 0;
        int totalCount = 0;

        public const int ExpectedNumberOfArguments = 1; 
        public ShowInventoryStockCommand(IList<string> commandParameters, IRepository repository)
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
            //CommandName[ShowInventoryStock], Company name[Sky]

            // Original command form: ShowInventoryStock
            // Parameters:
            //  [0] - inventory name

            var companyName = this.CommandParameters[0];

            var sb = new StringBuilder();

            DataTable table = new();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Product Name", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(decimal));
            table.Columns.Add("Product Value", typeof(string));

            var query = this.Repository.Company
                         .SelectMany(company => company.Inventory)
                         .Where(x => x.Name == companyName)
                         .SelectMany(company => company.Products)
                         .Select(product => new { product.Id, product.Name, product.Quantity, product.Price, Value = product.Quantity * product.Price + " $" });

            if (!query.Any())
            {
                throw new InvalidUserInputException("Inventory doesn't exist");
            }

            foreach (var item in query!)
            {
                table.Rows.Add(item.Id, item.Name, item.Quantity, item.Price, item.Value);
            }

            foreach (var item in query)
            {
                if(item.Name.ToLower().Contains("cream"))
                {
                    cream++;
                }
                if (item.Name.ToLower().Contains("lipstick"))
                {
                    lipstick++;
                }
                if (item.Name.ToLower().Contains("perfume"))
                {
                    perfume++;
                }
            }

            totalCount = cream + perfume + lipstick;

            var tableString = ConsoleTableBuilder.From(table).WithFormat(ConsoleTableBuilderFormat.Alternative).Export().ToString();

            sb.AppendLine($"The inventory contains a total of {totalCount} products, including {cream} creams, {perfume} perfumes, and {lipstick} lipsticks.");
            sb.AppendLine(tableString);

            return sb.ToString();
        }
    }
}
