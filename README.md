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
| RegisterUser         | Register a new user by name and password. Password must be 15 or more characters and must contain at least 4 special symbols, lower letters, upper letters, and numbers. | [RegisterUser], [Username], [Name], [Last name], [Password], [Company name], [Role in the company] |
| Login                | Log in to the system using a registered username and password.                              | [Login], [Username], [Password]                                                              |
| Logout               | Log out of the system.                                                                      | [Logout]                                                                                     |
| CreateInventory      | Create a new inventory by name and company ID.                                              | [CreateInventory], [Inventory name], [Company ID]                                            |
| CreateCream          | Create a new cream product by name, price, quantity, and inventory ID.                      | [CreateCream], [Product name], [Brand], [Price], [Quantity], [Inventory ID]                  |
| CreatePerfume        | Create a new perfume product by name, price, quantity, and inventory ID.                    | [CreatePerfume], [Product name], [Brand], [Price], [Quantity], [Inventory ID]                |
| CreateLipstick       | Create a new lipstick product by name, price, quantity, and inventory ID.                   | [CreateLipstick], [Product name], [Brand], [Price], [Quantity], [Inventory ID]               |
| ShowInventoryStock   | Show the stock of a specific inventory by inventory ID.                                     | [ShowInventoryStock], [Inventory ID]                                                         |
| ShowAllCompanies     | Show all companies in the system.                                                           | [ShowAllCompanies]                                                                           |
| ShowProductById      | Show the details of a specific product by product ID.                                       | [ShowProductById], [Product ID]                                                              |
| ChangeProductValue   | Change the value of a specific product by product ID.                                       | [ChangeProductValue], [Product ID], [Name/Brand/Price/Quantity], [New value]                 |
| RemoveProduct        | Remove a product from an inventory by product ID.                                           | [RemoveProduct], [Product ID], [Inventory ID]                                                |
| RemoveInventory      | Remove an inventory from a company by inventory ID.                                         | [RemoveInventory], [Inventory ID], [Company ID]                                              |
| ChangePassword       | Change the password for the currently logged in user.                                       | [ChangePassword], [Username], [New Password]                                                 |
| ChangeUsername       | Change the username for the currently logged in user.                                       | [ChangePassword], [Old Username], [New Username]                                             |
| BuyProduct           | Buy product from a company                                                                  | [BuyProduct], [Product name], [Quantity]                                                     |

## Sample Input
```none
RegisterUser, vasilring, Vasil, Lyubenov, C!8AFeq#(v69G&*, SkyLife, Manager
Logout
RegisterUser, vasil, Vasil, Lyubenov, C!8AFeq#(v69G&*, Cosmetics, Client
ChangePassword, vasilring, h867#$%HCAebYwi
ChangeUsername, vasilring, vasilrig
Logout
Login, vasilring, C!8AFeq#(v69G&*
ChangePassword, vasilring, h867#$%HCAebYwi
ChangeUsername, vasilring, vasilrig
Logout
Login, vasilring, C!8AFeq#(v69G&*
Login, vasilrig, h867#$%HCAebYwi 
CreateInventory, Sky, SkyLife
CreateLipstick, Dermacol Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
CreatePerfume, Dermacol Perfume, Dermacol, Simple Description, 20.00, 116, Sky
CreateCream, Dermacol Cream, Dermacol, Simple Description, 30.00, 126, Sky
CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 15.00, 1060, Sky
CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 25.00, 1016, Sky
CreateCream, Night Havier Cream, Dermacol, Simple Description, 35.00, 1206, Sky
RemoveInventory, SkyLife, Sky
ShowInventoryStock, SkyLife
CreateInventory, Sky, SkyLife
CreateLipstick, Dermacol Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
CreatePerfume, Dermacol Perfume, Dermacol, Simple Description, 20.00, 116, Sky
CreateCream, Dermacol Cream, Dermacol, Simple Description, 30.00, 126, Sky
CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 15.00, 1060, Sky
CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 25.00, 1016, Sky
CreateCream, Night Havier Cream, Dermacol, Simple Description, 35.00, 1206, Sky
ShowInventoryStock, SkyLife
FilterProductsBy, price, desc
FilterProductsBy, price, asc
FilterProductsBy, name, cream
FilterProductsBy, name, lipstick
FilterProductsBy, name, perfume
FilterProductsBy, name, perfume, asc
FilterProductsBy, name, perfume, desc
ShowInventoryStock, SkyLife
ChangeProductValue, 2, name, Dermacol Night Cream
ChangeProductValue, 2, price, 33.00
ChangeProductValue, 2, quantity, 300
ShowProductById, 1
ShowProductById, 2
ShowProductById, 3
ShowProductById, 4
ShowProductById, 5
ShowProductById, 6
RemoveProduct, 3, Sky
ShowProductById, 1
ShowProductById, 2
ShowProductById, 3
ShowProductById, 4
ShowProductById, 5
ShowProductById, 6
ShowInventoryStock, SkyLife
BuyProduct, Blue Lipstick, 56
ShowAllCompanies
Logout
Login, vasil, C!8AFeq#(v69G&*
CreateInventory, Sky, SkyLife
CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 20.00, 116, Sky
CreateCream, Night Havier Cream, Dermacol, Simple Description, 30.00, 126, Sky
ChangeProductValue, 2, name, Dermacol Night Cream
RemoveProduct, 3, Sky
RemoveInventory, SkyLife, Sky
ShowInventoryStock, SkyLife
BuyProduct, Dermacol Lipstick, -56
BuyProduct, Dermacol Lipstick, 50
BuyProduct, Blue Lipstick, 1206
ShowInventoryStock, SkyLife
```

#### Expected Output
```none
RegisterUser, vasilring, Vasil, Lyubenov, C!8AFeq#(v69G&*, SkyLife, Manager
User with username "vasilring", name "Vasil", and role "Manager" has been successfully registered. We have also created a company named "SkyLife" for this user.
####################

Logout
You logged out!
####################

RegisterUser, vasil, Vasil, Lyubenov, C!8AFeq#(v69G&*, Cosmetics, Client
User with username "vasil", name "Vasil", and role "Client" has been successfully registered. We have also created a company named "Cosmetics" for this user.
####################

ChangePassword, vasilring, h867#$%HCAebYwi
You cannot change other users passwords
ChangeUsername, vasilring, vasilrig
You cannot change other users username
Logout
You logged out!
####################

Login, vasilring, C!8AFeq#(v69G&*
User vasilring successfully logged in!
####################

ChangePassword, vasilring, h867#$%HCAebYwi
Password of user: vasilring was changed to h867#$%HCAebYwi :D
####################

ChangeUsername, vasilring, vasilrig
Username changed to vasilrig successfully
####################

Logout
You logged out!
####################

Login, vasilring, C!8AFeq#(v69G&*
User with name vasilring was not found!
Login, vasilrig, h867#$%HCAebYwi
User vasilrig successfully logged in!
####################

CreateInventory, Sky, SkyLife
Inventory with name: Sky was created
####################

CreateLipstick, Dermacol Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
Product 'Lipstick' with  Id: 1 was created
####################

CreatePerfume, Dermacol Perfume, Dermacol, Simple Description, 20.00, 116, Sky
Product 'Perfume' with  Id: 2 was created
####################

CreateCream, Dermacol Cream, Dermacol, Simple Description, 30.00, 126, Sky
Product 'Cream' with  Id: 3 was created
####################

CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 15.00, 1060, Sky
Product 'Lipstick' with  Id: 4 was created
####################

CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 25.00, 1016, Sky
Product 'Perfume' with  Id: 5 was created
####################

CreateCream, Night Havier Cream, Dermacol, Simple Description, 35.00, 1206, Sky
Product 'Cream' with  Id: 6 was created
####################

RemoveInventory, SkyLife, Sky
Inventory with name: Sky was removed
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 0 products, including 0 creams, 0 perfumes, and 0 lipsticks.
+--------------+----------+-------+---------------+
| Product Name | Quantity | Price | Product Value |
+--------------+----------+-------+---------------+
####################

CreateInventory, Sky, SkyLife
Inventory with name: Sky was created
####################

CreateLipstick, Dermacol Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
Product 'Lipstick' with  Id: 1 was created
####################

CreatePerfume, Dermacol Perfume, Dermacol, Simple Description, 20.00, 116, Sky
Product 'Perfume' with  Id: 2 was created
####################

CreateCream, Dermacol Cream, Dermacol, Simple Description, 30.00, 126, Sky
Product 'Cream' with  Id: 3 was created
####################

CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 15.00, 1060, Sky
Product 'Lipstick' with  Id: 4 was created
####################

CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 25.00, 1016, Sky
Product 'Perfume' with  Id: 5 was created
####################

CreateCream, Night Havier Cream, Dermacol, Simple Description, 35.00, 1206, Sky
Product 'Cream' with  Id: 6 was created
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 6 products, including 2 creams, 2 perfumes, and 2 lipsticks.
+--------------------+----------+-------+---------------+
| Product Name       | Quantity | Price | Product Value |
+--------------------+----------+-------+---------------+
| Dermacol Lipstick  | 106      | 10.00 | 1060.00 $     |
+--------------------+----------+-------+---------------+
| Dermacol Perfume   | 116      | 20.00 | 2320.00 $     |
+--------------------+----------+-------+---------------+
| Dermacol Cream     | 126      | 30.00 | 3780.00 $     |
+--------------------+----------+-------+---------------+
| Blue Lipstick      | 1060     | 15.00 | 15900.00 $    |
+--------------------+----------+-------+---------------+
| Hugo Boss Perfume  | 1016     | 25.00 | 25400.00 $    |
+--------------------+----------+-------+---------------+
| Night Havier Cream | 1206     | 35.00 | 42210.00 $    |
+--------------------+----------+-------+---------------+
####################

FilterProductsBy, price, desc
+--------------------+----------+-------+
| Product Name       | Quantity | Price |
+--------------------+----------+-------+
| Night Havier Cream | 1206     | 35.00 |
+--------------------+----------+-------+
| Dermacol Cream     | 126      | 30.00 |
+--------------------+----------+-------+
| Hugo Boss Perfume  | 1016     | 25.00 |
+--------------------+----------+-------+
| Dermacol Perfume   | 116      | 20.00 |
+--------------------+----------+-------+
| Blue Lipstick      | 1060     | 15.00 |
+--------------------+----------+-------+
| Dermacol Lipstick  | 106      | 10.00 |
+--------------------+----------+-------+
####################

FilterProductsBy, price, asc
+--------------------+----------+-------+
| Product Name       | Quantity | Price |
+--------------------+----------+-------+
| Dermacol Lipstick  | 106      | 10.00 |
+--------------------+----------+-------+
| Blue Lipstick      | 1060     | 15.00 |
+--------------------+----------+-------+
| Dermacol Perfume   | 116      | 20.00 |
+--------------------+----------+-------+
| Hugo Boss Perfume  | 1016     | 25.00 |
+--------------------+----------+-------+
| Dermacol Cream     | 126      | 30.00 |
+--------------------+----------+-------+
| Night Havier Cream | 1206     | 35.00 |
+--------------------+----------+-------+
####################

FilterProductsBy, name, cream
+--------------------+----------+-------+
| Product Name       | Quantity | Price |
+--------------------+----------+-------+
| Dermacol Cream     | 126      | 30.00 |
+--------------------+----------+-------+
| Night Havier Cream | 1206     | 35.00 |
+--------------------+----------+-------+
####################

FilterProductsBy, name, lipstick
+-------------------+----------+-------+
| Product Name      | Quantity | Price |
+-------------------+----------+-------+
| Dermacol Lipstick | 106      | 10.00 |
+-------------------+----------+-------+
| Blue Lipstick     | 1060     | 15.00 |
+-------------------+----------+-------+
####################

FilterProductsBy, name, perfume
+-------------------+----------+-------+
| Product Name      | Quantity | Price |
+-------------------+----------+-------+
| Dermacol Perfume  | 116      | 20.00 |
+-------------------+----------+-------+
| Hugo Boss Perfume | 1016     | 25.00 |
+-------------------+----------+-------+
####################

FilterProductsBy, name, perfume, asc
+-------------------+----------+-------+
| Product Name      | Quantity | Price |
+-------------------+----------+-------+
| Dermacol Perfume  | 116      | 20.00 |
+-------------------+----------+-------+
| Hugo Boss Perfume | 1016     | 25.00 |
+-------------------+----------+-------+
####################

FilterProductsBy, name, perfume, desc
+-------------------+----------+-------+
| Product Name      | Quantity | Price |
+-------------------+----------+-------+
| Hugo Boss Perfume | 1016     | 25.00 |
+-------------------+----------+-------+
| Dermacol Perfume  | 116      | 20.00 |
+-------------------+----------+-------+
####################

ShowInventoryStock, SkyLife
The inventory contains a total of 6 products, including 2 creams, 2 perfumes, and 2 lipsticks.
+--------------------+----------+-------+---------------+
| Product Name       | Quantity | Price | Product Value |
+--------------------+----------+-------+---------------+
| Dermacol Lipstick  | 106      | 10.00 | 1060.00 $     |
+--------------------+----------+-------+---------------+
| Dermacol Perfume   | 116      | 20.00 | 2320.00 $     |
+--------------------+----------+-------+---------------+
| Dermacol Cream     | 126      | 30.00 | 3780.00 $     |
+--------------------+----------+-------+---------------+
| Blue Lipstick      | 1060     | 15.00 | 15900.00 $    |
+--------------------+----------+-------+---------------+
| Hugo Boss Perfume  | 1016     | 25.00 | 25400.00 $    |
+--------------------+----------+-------+---------------+
| Night Havier Cream | 1206     | 35.00 | 42210.00 $    |
+--------------------+----------+-------+---------------+
####################

ChangeProductValue, 2, name, Dermacol Night Cream
Name of product with 2 was changed to Dermacol Night Cream
####################

ChangeProductValue, 2, price, 33.00
Price of product with 2 was changed to 33.00
####################

ChangeProductValue, 2, quantity, 300
Quantity of product with 2 was changed to 300
####################

ShowProductById, 1
+----+-------------------+----------+----------+-------+
| Id | Product Name      | Brand    | Quantity | Price |
+----+-------------------+----------+----------+-------+
| 1  | Dermacol Lipstick | Dermacol | 106      | 10.00 |
+----+-------------------+----------+----------+-------+
####################

ShowProductById, 2
+----+----------------------+----------+----------+-------+
| Id | Product Name         | Brand    | Quantity | Price |
+----+----------------------+----------+----------+-------+
| 2  | Dermacol Night Cream | Dermacol | 300      | 33.00 |
+----+----------------------+----------+----------+-------+
####################

ShowProductById, 3
+----+----------------+----------+----------+-------+
| Id | Product Name   | Brand    | Quantity | Price |
+----+----------------+----------+----------+-------+
| 3  | Dermacol Cream | Dermacol | 126      | 30.00 |
+----+----------------+----------+----------+-------+
####################

ShowProductById, 4
+----+---------------+----------+----------+-------+
| Id | Product Name  | Brand    | Quantity | Price |
+----+---------------+----------+----------+-------+
| 4  | Blue Lipstick | Dermacol | 1060     | 15.00 |
+----+---------------+----------+----------+-------+
####################

ShowProductById, 5
+----+-------------------+----------+----------+-------+
| Id | Product Name      | Brand    | Quantity | Price |
+----+-------------------+----------+----------+-------+
| 5  | Hugo Boss Perfume | Dermacol | 1016     | 25.00 |
+----+-------------------+----------+----------+-------+
####################

ShowProductById, 6
+----+--------------------+----------+----------+-------+
| Id | Product Name       | Brand    | Quantity | Price |
+----+--------------------+----------+----------+-------+
| 6  | Night Havier Cream | Dermacol | 1206     | 35.00 |
+----+--------------------+----------+----------+-------+
####################

RemoveProduct, 3, Sky
Product with Id: 3 was removed
####################

ShowProductById, 1
+----+-------------------+----------+----------+-------+
| Id | Product Name      | Brand    | Quantity | Price |
+----+-------------------+----------+----------+-------+
| 1  | Dermacol Lipstick | Dermacol | 106      | 10.00 |
+----+-------------------+----------+----------+-------+
####################

ShowProductById, 2
+----+----------------------+----------+----------+-------+
| Id | Product Name         | Brand    | Quantity | Price |
+----+----------------------+----------+----------+-------+
| 2  | Dermacol Night Cream | Dermacol | 300      | 33.00 |
+----+----------------------+----------+----------+-------+
####################

ShowProductById, 3
+----+---------------+----------+----------+-------+
| Id | Product Name  | Brand    | Quantity | Price |
+----+---------------+----------+----------+-------+
| 3  | Blue Lipstick | Dermacol | 1060     | 15.00 |
+----+---------------+----------+----------+-------+
####################

ShowProductById, 4
+----+-------------------+----------+----------+-------+
| Id | Product Name      | Brand    | Quantity | Price |
+----+-------------------+----------+----------+-------+
| 4  | Hugo Boss Perfume | Dermacol | 1016     | 25.00 |
+----+-------------------+----------+----------+-------+
####################

ShowProductById, 5
+----+--------------------+----------+----------+-------+
| Id | Product Name       | Brand    | Quantity | Price |
+----+--------------------+----------+----------+-------+
| 5  | Night Havier Cream | Dermacol | 1206     | 35.00 |
+----+--------------------+----------+----------+-------+
####################

ShowProductById, 6
No product was found with the given ID.
ShowInventoryStock, SkyLife
The inventory contains a total of 5 products, including 2 creams, 1 perfumes, and 2 lipsticks.
+----------------------+----------+-------+---------------+
| Product Name         | Quantity | Price | Product Value |
+----------------------+----------+-------+---------------+
| Dermacol Lipstick    | 106      | 10.00 | 1060.00 $     |
+----------------------+----------+-------+---------------+
| Dermacol Night Cream | 300      | 33.00 | 9900.00 $     |
+----------------------+----------+-------+---------------+
| Blue Lipstick        | 1060     | 15.00 | 15900.00 $    |
+----------------------+----------+-------+---------------+
| Hugo Boss Perfume    | 1016     | 25.00 | 25400.00 $    |
+----------------------+----------+-------+---------------+
| Night Havier Cream   | 1206     | 35.00 | 42210.00 $    |
+----------------------+----------+-------+---------------+
####################

BuyProduct, Blue Lipstick, 56
Access denied. You are not authorized to execute this command.
ShowAllCompanies
+--------------+
| Company Name |
+--------------+
| Cosmetics    |
+--------------+
| SkyLife      |
+--------------+
####################

Logout
You logged out!
####################

Login, vasil, C!8AFeq#(v69G&*
User vasil successfully logged in!
####################

CreateInventory, Sky, SkyLife
Access denied. You are not authorized to execute this command.
CreateLipstick, Blue Lipstick, Dermacol, Simple Description, 10.00, 106, Sky
Access denied. You are not authorized to execute this command.
CreatePerfume, Hugo Boss Perfume, Dermacol, Simple Description, 20.00, 116, Sky
Access denied. You are not authorized to execute this command.
CreateCream, Night Havier Cream, Dermacol, Simple Description, 30.00, 126, Sky
Access denied. You are not authorized to execute this command.
ChangeProductValue, 2, name, Dermacol Night Cream
Access denied. You are not authorized to execute this command.
RemoveProduct, 3, Sky
Access denied. You are not authorized to execute this command.
RemoveInventory, SkyLife, Sky
Access denied. You are not authorized to execute this command.
ShowInventoryStock, SkyLife
The inventory contains a total of 5 products, including 2 creams, 1 perfumes, and 2 lipsticks.
+----------------------+----------+-------+---------------+
| Product Name         | Quantity | Price | Product Value |
+----------------------+----------+-------+---------------+
| Dermacol Lipstick    | 106      | 10.00 | 1060.00 $     |
+----------------------+----------+-------+---------------+
| Dermacol Night Cream | 300      | 33.00 | 9900.00 $     |
+----------------------+----------+-------+---------------+
| Blue Lipstick        | 1060     | 15.00 | 15900.00 $    |
+----------------------+----------+-------+---------------+
| Hugo Boss Perfume    | 1016     | 25.00 | 25400.00 $    |
+----------------------+----------+-------+---------------+
| Night Havier Cream   | 1206     | 35.00 | 42210.00 $    |
+----------------------+----------+-------+---------------+
####################

BuyProduct, Dermacol Lipstick, -56
Quantity cannot be negative!
BuyProduct, Dermacol Lipstick, 50
Successfully bought 50 pieces from Dermacol Lipstick product
####################

BuyProduct, Blue Lipstick, 1206
Insufficient quantity of product  Blue Lipstick in the inventory.
ShowInventoryStock, SkyLife
The inventory contains a total of 5 products, including 2 creams, 1 perfumes, and 2 lipsticks.
+----------------------+----------+-------+---------------+
| Product Name         | Quantity | Price | Product Value |
+----------------------+----------+-------+---------------+
| Dermacol Lipstick    | 56       | 10.00 | 560.00 $      |
+----------------------+----------+-------+---------------+
| Dermacol Night Cream | 300      | 33.00 | 9900.00 $     |
+----------------------+----------+-------+---------------+
| Blue Lipstick        | 1060     | 15.00 | 15900.00 $    |
+----------------------+----------+-------+---------------+
| Hugo Boss Perfume    | 1016     | 25.00 | 25400.00 $    |
+----------------------+----------+-------+---------------+
| Night Havier Cream   | 1206     | 35.00 | 42210.00 $    |
+----------------------+----------+-------+---------------+
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
