# Inventory Management System

This is a command-line based inventory management system that allows you to manage different company inventories, and buyers of the stock.
You can also register and manage users, and assign products to different inventories of the companies.
This system provides features like adding products to inventory, listing all products of a company, assigning products to a buyer, and listing all buyers of a product.

## Usage

#### To use the app, you need to follow these steps:

1. Register a user using the RegisterUser command. This will create a new user and log in the user.

2. Create a company using the CreateCompany command. This will create a new company.

3. Create a product using the CreateProduct command. This will create a new product with a unique ID and add it to the specified company's inventory.

4. Use the other commands to manage your products, inventories, and buyers. For example, you can use the ShowProductByID command to view the details of a specific product, or the ListProductsByCompany command to list all products of a specific company.

`Note` that you must register a user and create a company before you can create a product. Additionally, you can create multiple inventories for a company, and add products to those inventories as needed.

## Features

#### The system has the following features:

1. Create a company with multiple inventories
2. Create a manager to add products to the inventories
3. Create clients to shop for products
4. View the products in the inventory
5. Add products to the inventory
6. Remove products from the inventory
7. Update the quantity of products in the inventory
8. Calculate the total price of the products in the inventory
9. Allow clients to buy products

## Commands

| Command              | Description                                                                                 | Input                                                                                        |
|----------------------|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| RegisterUser         | Register a new user by name and password. Password must be 15 or more characters and must contain at least 3 special symbols, lower letters, upper letters, and numbers. | [RegisterUser], [Username], [Name], [Last name], [Password], [Company name], [Role in the company] |
| Login                | Log in to the system using a registered username and password.                              | [Login], [Username], [Password]                                                              |
| Logout               | Log out of the system.                                                                      | [Logout]                                                                                     |
| CreateInventory      | Create a new inventory by name and company ID.                                              | [CreateInventory], [Inventory name], [Company ID]                                            |
| CreateCream          | Create a new cream product by name, price, quantity, and inventory ID.                      | [CreateCream], [Product name], [Brand], [Description], [Price], [Quantity], [Inventory ID]   |
| CreatePerfume        | Create a new perfume product by name, price, quantity, and inventory ID.                    | [CreatePerfume], [Product name], [Brand], [Description], [Price], [Quantity], [Inventory ID] |
| CreateLipstick       | Create a new lipstick product by name, price, quantity, and inventory ID.                   | [CreateLipstick], [Product name], [Brand], [Description],[Price], [Quantity], [Inventory ID] |
| ShowInventoryStock   | Show the stock of a specific inventory by inventory ID.                                     | [ShowInventoryStock], [Inventory ID]                                                         |
| ShowAllCompanies     | Show all companies in the system.                                                           | [ShowAllCompanies]                                                                           |
| ShowProductById      | Show the details of a specific product by product ID.                                       | [ShowProductById], [Product ID]                                                              |
| ChangeProductValue   | Change the value of a specific product by product ID.                                       | [ChangeProductValue], [Product ID], [Name/Brand/Price/Quantity], [New value]                 |
| RemoveProduct        | Remove a product from an inventory by product ID.                                           | [RemoveProduct], [Product ID], [Inventory ID]                                                |
| RemoveInventory      | Remove an inventory from a company by inventory ID.                                         | [RemoveInventory], [Inventory ID], [Company ID]                                              |
| ChangePassword       | Change the password for the currently logged in user.                                       | [ChangePassword], [Username], [New Password]                                                 |
| ChangeUsername       | Change the username for the currently logged in user.                                       | [ChangePassword], [Old Username], [New Username]                                             |
| BuyProduct           | Buy product from a company                                                                  | [BuyProduct], [Product name], [Quantity]                                                     |
| FilterProductBy      | Filter products by name (cream, lipstick, or perfume), by price (ascending or descending), or by both name and price (ascending or descending)  | [FilterProducts], [Price/Name], [ACS||DESC/CREAM||LIPSTICK], [ACS/DESC]           |

## Sample Input without exception handling
```none
RegisterUser, vasilring, Vasil, Lyubenov, C!8AFeq#(v69G&*, SkyLife, Manager
ChangePassword, vasilring, h867#$%HCAebYwi
ChangeUsername, vasilring, vasilrig
Logout
Login, vasilrig, h867#$%HCAebYwi 
CreateInventory, Sky, SkyLife
CreateLipstick, Dermacol Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Sky
CreateLipstick, Cherry Lipstick, Nivea, Simple Description, 5.00, 60, Sky
CreatePerfume, Dermacol Peach Flower Perfume, Dermacol, Simple Description, 50.00, 1000, Sky
CreatePerfume, Hugo Boss Scent Perfume, Hugo Boss, Simple Description, 75.00, 1000, Sky
CreateCream, Dermacol Gold Elexir Night Cream, Dermacol, Simple Description, 29.90, 1000, Sky
CreateCream, Eye cream 24 h, Cosnobell, Simple Description, 200.00, 150, Sky
ShowInventoryStock, SkyLife
RemoveInventory, SkyLife, Sky
ShowInventoryStock, SkyLife
CreateInventory, Sky, SkyLife
CreateLipstick, Dermacol Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Sky
CreateLipstick, Cherry Lipstick, Nivea, Simple Description, 5.00, 100, Sky
CreatePerfume, Dermacol Peach Flower Perfume, Dermacol, Simple Description, 50.00, 1000, Sky
CreatePerfume, Hugo Boss Scent Perfume, Hugo Boss, Simple Description, 75.00, 125, Sky
CreateCream, Dermacol Gold Elexir Night Cream, Dermacol, Simple Description, 29.90, 1000, Sky
CreateCream, Eye cream 24 h, Cosnobell, Simple Description, 200.00, 150, Sky
ShowInventoryStock, SkyLife
FilterProductsBy, price, desc
FilterProductsBy, price, asc
FilterProductsBy, name, cream
FilterProductsBy, name, lipstick
FilterProductsBy, name, perfume
FilterProductsBy, name, perfume, asc
FilterProductsBy, name, perfume, desc
FilterProductsBy, name, cream, asc
FilterProductsBy, name, cream, desc
FilterProductsBy, name, lipstick, asc
FilterProductsBy, name, lipstick, desc
ChangeProductValue, 1, name, Strawberry Lipstick
ChangeProductValue, 1, price, 8.00
ChangeProductValue, 1, quantity, 90
ShowProductById, 1
ShowProductById, 2
ShowProductById, 3
ShowProductById, 4
ShowProductById, 5
ShowProductById, 6
RemoveProduct, 6, Sky
RemoveProduct, 5, Sky
RemoveProduct, 4, Sky
ShowProductById, 4
ShowProductById, 5
ShowProductById, 6
ShowInventoryStock, SkyLife
ShowAllCompanies
ShowAllUsers
Logout
RegisterUser, vasil, Vasil, Lyubenov, C!8AFeq#(v69G&*, Cosmetics, Client
ShowInventoryStock, SkyLife
BuyProduct, Strawberry Lipstick, 60
yes
BuyProduct, Dermacol Peach Flower Perfume, 260
no
ShowInventoryStock, SkyLife
```

#### Expected Output
```none
RegisterUser, vasilring, Vasil, Lyubenov, C!8AFeq#(v69G&*, SkyLife, Manager
User with username "vasilring", name "Vasil", and role "Manager" has been successfully registered. A new company named "SkyLife" has been created for this user.
####################

ChangePassword, vasilring, h867#$%HCAebYwi
The password for user "vasilring" has been successfully changed to "h867#$%HCAebYwi".
####################

ChangeUsername, vasilring, vasilrig
Username changed to vasilrig successfully
####################

Logout
You logged out!
####################

Login, vasilrig, h867#$%HCAebYwi
User vasilrig successfully logged in!
####################

CreateInventory, Sky, SkyLife
Inventory with name: Sky was created
####################

CreateLipstick, Dermacol Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Sky
Product 'Lipstick' with  Id: 1 was created
####################

CreateLipstick, Cherry Lipstick, Nivea, Simple Description, 5.00, 60, Sky
Product 'Lipstick' with  Id: 2 was created
####################

CreatePerfume, Dermacol Peach Flower Perfume, Dermacol, Simple Description, 50.00, 1000, Sky
Product 'Perfume' with  Id: 3 was created
####################

CreatePerfume, Hugo Boss Scent Perfume, Hugo Boss, Simple Description, 75.00, 1000, Sky
Product 'Perfume' with  Id: 4 was created
####################

CreateCream, Dermacol Gold Elexir Night Cream, Dermacol, Simple Description, 29.90, 1000, Sky
Product 'Cream' with  Id: 5 was created
####################

CreateCream, Eye cream 24 h, Cosnobell, Simple Description, 200.00, 150, Sky
Product 'Cream' with  Id: 6 was created
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 5 products, including 1 creams, 2 perfumes, and 2 lipsticks.
+----+----------------------------------+----------+--------+---------------+
| ID | Product Name                     | Quantity | Price  | Product Value |
+----+----------------------------------+----------+--------+---------------+
| 1  | Dermacol Matte Mania Lipstick    | 1000     | 12.50  | 12500.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 2  | Cherry Lipstick                  | 60       | 5.00   | 300.00 $      |
+----+----------------------------------+----------+--------+---------------+
| 3  | Dermacol Peach Flower Perfume    | 1000     | 50.00  | 50000.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 4  | Hugo Boss Scent Perfume          | 1000     | 75.00  | 75000.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 5  | Dermacol Gold Elexir Night Cream | 1000     | 29.90  | 29900.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 6  | Eye cream 24 h                   | 150      | 200.00 | 30000.00 $    |
+----+----------------------------------+----------+--------+---------------+
####################

RemoveInventory, SkyLife, Sky
Inventory with name: Sky was removed
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 0 products, including 0 creams, 0 perfumes, and 0 lipsticks.
+----+--------------+----------+-------+---------------+
| ID | Product Name | Quantity | Price | Product Value |
+----+--------------+----------+-------+---------------+
####################

CreateInventory, Sky, SkyLife
Inventory with name: Sky was created
####################

CreateLipstick, Dermacol Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Sky
Product 'Lipstick' with  Id: 1 was created
####################

CreateLipstick, Cherry Lipstick, Nivea, Simple Description, 5.00, 100, Sky
Product 'Lipstick' with  Id: 2 was created
####################

CreatePerfume, Dermacol Peach Flower Perfume, Dermacol, Simple Description, 50.00, 1000, Sky
Product 'Perfume' with  Id: 3 was created
####################

CreatePerfume, Hugo Boss Scent Perfume, Hugo Boss, Simple Description, 75.00, 125, Sky
Product 'Perfume' with  Id: 4 was created
####################

CreateCream, Dermacol Gold Elexir Night Cream, Dermacol, Simple Description, 29.90, 1000, Sky
Product 'Cream' with  Id: 5 was created
####################

CreateCream, Eye cream 24 h, Cosnobell, Simple Description, 200.00, 150, Sky
Product 'Cream' with  Id: 6 was created
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 5 products, including 1 creams, 2 perfumes, and 2 lipsticks.
+----+----------------------------------+----------+--------+---------------+
| ID | Product Name                     | Quantity | Price  | Product Value |
+----+----------------------------------+----------+--------+---------------+
| 1  | Dermacol Matte Mania Lipstick    | 1000     | 12.50  | 12500.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 2  | Cherry Lipstick                  | 100      | 5.00   | 500.00 $      |
+----+----------------------------------+----------+--------+---------------+
| 3  | Dermacol Peach Flower Perfume    | 1000     | 50.00  | 50000.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 4  | Hugo Boss Scent Perfume          | 125      | 75.00  | 9375.00 $     |
+----+----------------------------------+----------+--------+---------------+
| 5  | Dermacol Gold Elexir Night Cream | 1000     | 29.90  | 29900.00 $    |
+----+----------------------------------+----------+--------+---------------+
| 6  | Eye cream 24 h                   | 150      | 200.00 | 30000.00 $    |
+----+----------------------------------+----------+--------+---------------+
####################

FilterProductsBy, price, desc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
| Hugo Boss Scent Perfume          | 125      | 75.00  |
+----------------------------------+----------+--------+
| Dermacol Peach Flower Perfume    | 1000     | 50.00  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Dermacol Matte Mania Lipstick    | 1000     | 12.50  |
+----------------------------------+----------+--------+
| Cherry Lipstick                  | 100      | 5.00   |
+----------------------------------+----------+--------+
####################

FilterProductsBy, price, asc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Cherry Lipstick                  | 100      | 5.00   |
+----------------------------------+----------+--------+
| Dermacol Matte Mania Lipstick    | 1000     | 12.50  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Dermacol Peach Flower Perfume    | 1000     | 50.00  |
+----------------------------------+----------+--------+
| Hugo Boss Scent Perfume          | 125      | 75.00  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
####################

FilterProductsBy, name, cream
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
####################

FilterProductsBy, name, lipstick
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Matte Mania Lipstick | 1000     | 12.50 |
+-------------------------------+----------+-------+
| Cherry Lipstick               | 100      | 5.00  |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Peach Flower Perfume | 1000     | 50.00 |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 125      | 75.00 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume, asc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Peach Flower Perfume | 1000     | 50.00 |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 125      | 75.00 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume, desc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 125      | 75.00 |
+-------------------------------+----------+-------+
| Dermacol Peach Flower Perfume | 1000     | 50.00 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, cream, asc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
####################

FilterProductsBy, name, cream, desc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
####################

FilterProductsBy, name, lipstick, asc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Cherry Lipstick               | 100      | 5.00  |
+-------------------------------+----------+-------+
| Dermacol Matte Mania Lipstick | 1000     | 12.50 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, lipstick, desc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Matte Mania Lipstick | 1000     | 12.50 |
+-------------------------------+----------+-------+
| Cherry Lipstick               | 100      | 5.00  |
+-------------------------------+----------+-------+
####################

ChangeProductValue, 1, name, Strawberry Lipstick
Name of product with 1 was changed to Strawberry Lipstick
####################

ChangeProductValue, 1, price, 8.00
Price of product with 1 was changed to 8.00
####################

ChangeProductValue, 1, quantity, 90
Quantity of product with 1 was changed to 90
####################

ShowProductById, 1
+----+---------------------+----------+----------+-------+
| Id | Product Name        | Brand    | Quantity | Price |
+----+---------------------+----------+----------+-------+
| 1  | Strawberry Lipstick | Dermacol | 90       | 8.00  |
+----+---------------------+----------+----------+-------+
####################

ShowProductById, 2
+----+-----------------+-------+----------+-------+
| Id | Product Name    | Brand | Quantity | Price |
+----+-----------------+-------+----------+-------+
| 2  | Cherry Lipstick | Nivea | 100      | 5.00  |
+----+-----------------+-------+----------+-------+
####################

ShowProductById, 3
+----+-------------------------------+----------+----------+-------+
| Id | Product Name                  | Brand    | Quantity | Price |
+----+-------------------------------+----------+----------+-------+
| 3  | Dermacol Peach Flower Perfume | Dermacol | 1000     | 50.00 |
+----+-------------------------------+----------+----------+-------+
####################

ShowProductById, 4
+----+-------------------------+-----------+----------+-------+
| Id | Product Name            | Brand     | Quantity | Price |
+----+-------------------------+-----------+----------+-------+
| 4  | Hugo Boss Scent Perfume | Hugo Boss | 125      | 75.00 |
+----+-------------------------+-----------+----------+-------+
####################

ShowProductById, 5
+----+----------------------------------+----------+----------+-------+
| Id | Product Name                     | Brand    | Quantity | Price |
+----+----------------------------------+----------+----------+-------+
| 5  | Dermacol Gold Elexir Night Cream | Dermacol | 1000     | 29.90 |
+----+----------------------------------+----------+----------+-------+
####################

ShowProductById, 6
+----+----------------+-----------+----------+--------+
| Id | Product Name   | Brand     | Quantity | Price  |
+----+----------------+-----------+----------+--------+
| 6  | Eye cream 24 h | Cosnobell | 150      | 200.00 |
+----+----------------+-----------+----------+--------+
####################

RemoveProduct, 6, Sky
Product with ID: 6 has been successfully removed. The IDs of other products have been adjusted.
####################

RemoveProduct, 5, Sky
Product with ID: 5 has been successfully removed. The IDs of other products have been adjusted.
####################

RemoveProduct, 4, Sky
Product with ID: 4 has been successfully removed. The IDs of other products have been adjusted.
####################

ShowProductById, 4
No product was found with the given ID.
####################

ShowProductById, 5
No product was found with the given ID.
####################

ShowProductById, 6
No product was found with the given ID.
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 90       | 8.00  | 720.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 100      | 5.00  | 500.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 3  | Dermacol Peach Flower Perfume | 1000     | 50.00 | 50000.00 $    |
+----+-------------------------------+----------+-------+---------------+
####################

ShowAllCompanies
+--------------+
| Company Name |
+--------------+
| SkyLife      |
+--------------+
####################

ShowAllUsers
+-----------+
| User Name |
+-----------+
| vasilrig  |
+-----------+
####################

Logout
You logged out!
####################

RegisterUser, vasil, Vasil, Lyubenov, C!8AFeq#(v69G&*, Cosmetics, Client
User with username "vasil", name "Vasil", and role "Client" has been successfully registered. A new company named "Cosmetics" has been created for this user.
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 90       | 8.00  | 720.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 100      | 5.00  | 500.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 3  | Dermacol Peach Flower Perfume | 1000     | 50.00 | 50000.00 $    |
+----+-------------------------------+----------+-------+---------------+
####################

BuyProduct, Strawberry Lipstick, 60
You are about to buy Strawberry Lipstick, 60 piece's from it. Are you sure you want to continue?

Press yes or no!
yes
Successfully bought 60 pieces from Strawberry Lipstick product
####################

BuyProduct, Dermacol Peach Flower Perfume, 260
You are about to buy Dermacol Peach Flower Perfume, 260 piece's from it. Are you sure you want to continue?

Press yes or no!
no
Successfully bought 260 pieces from Dermacol Peach Flower Perfume product
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 30       | 8.00  | 240.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 100      | 5.00  | 500.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 3  | Dermacol Peach Flower Perfume | 740      | 50.00 | 37000.00 $    |
+----+-------------------------------+----------+-------+---------------+
####################
````

## Client Restrictions in Inventory Management System

The inventory management system includes restrictions for clients to ensure they have limited access and capabilities compared to managers. These restrictions are designed to maintain control over product creation and other critical functionalities. The following restrictions apply to clients:

- **Clients cannot create or modify products:**
  - Clients are restricted from using commands such as `CreateProduct` and `UpdateProduct`.
  - Only managers have the authority to create or modify products within the system.

- **Clients cannot manage inventories:**
  - Inventory management commands like `ACreateInventory` and `RemoveInventory` are disabled for clients.
  - Clients are not permitted to manipulate the contents of inventories.
  - Only managers can perform inventory management actions.

These restrictions ensure that clients have a restricted scope of actions within the inventory management system. By preventing them from creating products and managing inventories, the system maintains control over crucial functionalities while providing clients with a streamlined shopping experience.

Please note that these restrictions are in place to maintain system integrity and prevent unauthorized actions. Managers should be responsible for overseeing product creation and inventory management to ensure smooth operations within the system.

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
