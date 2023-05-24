//using InventoryManagementSystem.Core.Contracts;
//using InventoryManagementSystem.Core;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using InventoryManagementSystem.Models.Contracts;
//using InventoryManagementSystem.Models.Enums;
//using System.Runtime.CompilerServices;

//namespace InventoryManagementSystem.Tests
//{
//    internal class TestInitialize
//    {
//        public static int id = 1;
//        public static string username = "username Test";
//        public static string name = "Test Name";
//        public static string nameLip = "Test Lipstick";
//        public static string nameCre = "Test Cream";
//        public static string namePer = "Test Perfume";
//        public static string lastName = "Test Name";
//        public static string password = "C!8AFeq#(v69G&*";
//        public static string companyName = "SkyLife";
//        public static Role roleM = Role.Manager;
//        public static Role roleC = Role.Client;

//        public static string brand = "Test Brand";
//        public static string description = "TestDescription";
//        public static decimal price = 10;
//        public static int quantity = 10;

//        public static IProduct product;
//        public static ICream cream;
//        public static ILipstick lipstick;
//        public static IPerfumes perfume;
//        public static IUser user;
//        public static ICompany company;
//        public static IInventory inventory;
//        public static Repository repo;
//        public static ICommandFactory factory;

//        public static string noMatches = "No matches found!";
        
//        public static IRepository GetTestRepository()
//        {
//            repo = new Repository();

//            user = repo.CreateUserAndCompany(username, name, lastName, password, companyName, roleM);

//            repo.AddUser(user, companyName);

//            repo.LogUser(user);

//            inventory = repo.CreateInventory(name, companyName);
            
//            cream = repo.CreateCream(nameLip, brand, description, price, quantity, inventory);

//            lipstick = repo.CreateLipstick(nameCre, brand, description, price, quantity, inventory);

//            perfume = repo.CreatePerfume(namePer, brand, description, price, quantity, inventory);
            
//            return new Repository();
//        }
//    }
//}
