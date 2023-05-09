﻿using InventoryManagementSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Commands.CreateCommands
{
    internal class CreateInventoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public CreateInventoryCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {

            //ToDo use validator to validate expected arguments

            //Input:
            // CommandName[CreateInventory], Inventory name[Sky], Company name [SkyLife]

            // CreateInventory, Sky, SkyLife

            // Original command form: CreateInventory
            // Parameters:
            //  [0] - inventory name
            //  [1] - company name

            string inventoryName = CommandParameters[0];
            string companyName = CommandParameters[1];

            var inventory = Repository.CreateInventory(inventoryName, companyName);

            return inventory.ToString();
        }


    }
}