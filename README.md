# Inventory Management System

This is a command-line based inventory management system that allows you to manage different company inventories, and buyers of the stock.
You can also register and manage users, and assign products to different inventories of the companies.
This system provides features like adding products to inventory, listing all products of a company, assigning products to a buyer, and listing all buyers of a product.

## Usage
To use the app, you need to follow these steps:

1. Register a user using the RegisterUser command. This will create a new user and log in the user.

2. Create a company using the CreateCompany command. This will create a new company.

3. Create a product using the CreateProduct command. This will create a new product with a unique ID and add it to the specified company's inventory.

4. Use the other commands to manage your products, inventories, and buyers. For example, you can use the ShowProductByID command to view the details of a specific product, or the ListProductsByCompany command to list all products of a specific company.

`Note` that you must register a user and create a company before you can create a product. Additionally, you can create multiple inventories for a company, and add products to those inventories as needed.

## Features

The system has the following features:

1. Create a company with multiple inventories
2. Create a manager to add products to the inventories
3. Create clients to shop for products
4. View the products in the inventory
5. Add products to the inventory
6. Remove products from the inventory
7. Update the quantity of products in the inventory
8. Calculate the total price of the products in the inventory
9. Allow clients to add products to their shopping cart
10. Allow clients to view their shopping cart
11. Allow clients to checkout and purchase the products in their shopping cart

## Commands

| Command            | Description                                                                                 | Input                                                                         |
|--------------------|---------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------|
| RegisterUser       | Register a new user by name and password. Password must be 15 or more characters and must     [RegisterUser], [Username], [Password]  
                        contain at least 4 special symbols, lower letters, upper letters, and numbers.             |                                      |
| Login              | Log in to the system using a registered username and password.                              | [Login], [Username], [Password]                                               |
| Logout             | Log out of the system.                                                                      | [Logout]                                                                      |
| CreateCompany      | Create a new company by name.                                                               | [CreateCompany], [Company name]                                               |
| CreateInventory    | Create a new inventory by name and company ID.                                              | [CreateInventory], [Inventory name], [Company ID]                             |
| CreateCream        | Create a new cream product by name, price, quantity, and inventory ID.                      | [CreateCream], [Product name], [Price], [Quantity], [Inventory ID]            |
| CreatePerfume      | Create a new perfume product by name, price, quantity, and inventory ID.                    | [CreatePerfume], [Product name], [Price], [Quantity], [Inventory ID]          |
| CreateLipstick     | Create a new lipstick product by name, price, quantity, and inventory ID.                   | [CreateLipstick], [Product name], [Price], [Quantity], [Inventory ID]         |
| ShowInventoryStock | Show the stock of a specific inventory by inventory ID.                                     | [ShowInventoryStock], [Inventory ID]                                          |
| ShowAllCompanies   | Show all companies in the system.                                                           | [ShowAllCompanies]                                                            |
| ShowProductById    | Show the details of a specific product by product ID.                                       | [ShowProductById], [Product ID]                                               |
| ChangeProductValue | Change the value of a specific product by product ID.                                       | [ChangeProductValue], [Product ID], [Name/Price/Quantity], [New value]        |
| RemoveProduct      | Remove a product from an inventory by product ID.                                           | [RemoveProduct], [Product ID]                                                 |
| RemoveInventory    | Remove an inventory from a company by inventory ID.                                         | [RemoveInventory], [Inventory ID]                                             |





## Project Hierarchy and Entity Descriptions

#### The system has the following hierarchy of entities:

1. User: a registered user of the system.

2. Company: a company that has an inventory of products.

3. Inventory: a collection of products for a specific company.

4. Product: a specific item that can be bought and sold.

#### Each entity has the following attributes:

1. User: username, password.

2. Company: name.

3. Inventory: name, company ID.

4. Product: name, price, quantity, inventory ID.

`The system allows users to register, log in, and log out. Once logged in, users can create companies and inventory, they can also add product to the current inventory or remove them.`
