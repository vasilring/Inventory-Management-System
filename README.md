# Inventory Management System

This is a command-line based inventory management system that allows you to manage different company inventories, and buyers of the stock.
You can also register and manage users, and assign products to different inventories of the companies.
This system provides features like adding products to inventory, listing all products of a company, assigning products to a buyer, and listing all buyers of a product.

## Usage

#### To use the app, you need to follow these steps:

1. "Register a user using the RegisterUser command. This will create a new user, log in the user, and automatically create a new company for the user during the registration process."

2. Create a product using the '[CreateCream],[CreatePerfume],[CreateLipstick]'command. This will create a new product with a unique ID and add it to the specified company's inventory.

3. Use the other commands to manage your products, inventories, and buyers. For example, you can use the ShowProductByID command to view the details of a specific product, or the ShowInventoryStock command to list all products of a specific company.

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
| BuyProduct           | Buy products from different companies                                                       | [BuyProduct], [Brand],[Product name],[Inventory name], [Quantity]                            |
| FilterProductBy| Filter products by name (cream, lipstick, or perfume), by price (ascending or descending), or by both name and price (ascending or descending)| [FilterProducts], [Price/Name], [ASC/DESC/CREAM or LIPSTICK], [ASC/DESC]  |

## Note: Product Creation for Users from Different Companies

In the Inventory Management System, users from different companies have the ability to create the same products in their respective inventories that already exist in other companies' inventories. However, once a product has been created and exists in the system, users cannot create another product with the same name.

This approach allows users to have separate inventories with the same set of products, facilitating uniformity and consistency across companies. It prevents duplication of products and ensures that each product is uniquely identified by its name.

Please note that modifying existing products, such as changing their values or quantities, is still allowed for users within their respective inventories.

If a user attempts to create a product with a name that already exists in the system, an exception will be thrown, indicating that the product cannot be created. The system ensures that each product remains unique in the overall inventory management system.

## Command Exceptions

The following commands are available in the system, and they throw specific exceptions in certain conditions:

- `RegisterUser`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the password does not meet the required criteria.

- `Login`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the user does not exist or if the password is incorrect.

- `Logout`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if no user is currently logged in.

- `CreateInventory`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the user tries to create an inventory for another company.

- `CreateCream`, `CreatePerfume`, `CreateLipstick`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the user tries to create a product for another company.
  - Throws an exception if the price or quantity is negative.

- `ChangeProductValue`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the product does not exist.
  - Throws an exception if the new price or quantity is negative.

- `RemoveProduct`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the product does not exist.

- `ShowInventoryStock`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the inventory does not exist.

- `ShowProductById`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the product with the specified ID does not exist.

- `ChangePassword`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the new password does not meet the required criteria.

- `BuyProduct`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the quantity to buy is negative or exceeds the available quantity in the inventory.

- `FilterProductsBy`:
  - Throws an exception if the number of parameters is incorrect.
  - Throws an exception if the product name does not exist in the system.

Please refer to the actual code implementation for more detailed exception handling.

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
ShowInventoryStock, Sky
CreateInventory, Lipstick, SkyLife
CreateLipstick, Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Lipstick 
CreateLipstick, Strawberry Lipstick, Nivea, Simple Description, 5.00, 100, Lipstick
ShowInventoryStock, Lipstick
RemoveInventory, SkyLife, Lipstick
ShowInventoryStock, Lipstick
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
ShowInventoryStock, Sky
ShowAllCompanies
ShowAllUsers
Logout
RegisterUser, vasil, Vasil, Lyubenov, C!8AFeq#(v69G&*, Cosmetics, Client
ShowInventoryStock, Sky
BuyProduct, dermacol, strawberry lipstick, Sky, 60
yes
BuyProduct, Dermacol, peach flower Perfume, Sky, 260
no
ShowInventoryStock, Sky
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

ShowInventoryStock, Sky
The inventory contains a total of 6 products, including 2 creams, 2 perfumes, and 2 lipsticks.
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

CreateInventory, Lipstick, SkyLife
Inventory with name: Lipstick was created
####################

CreateLipstick, Matte Mania Lipstick, Dermacol, Simple Description, 12.50, 1000, Lipstick
Product 'Lipstick' with  Id: 7 was created
####################

CreateLipstick, Strawberry Lipstick, Nivea, Simple Description, 5.00, 100, Lipstick
Product 'Lipstick' with  Id: 8 was created
####################

ShowInventoryStock, Lipstick
The inventory contains a total of 2 products, including 0 creams, 0 perfumes, and 2 lipsticks.
+----+----------------------+----------+-------+---------------+
| ID | Product Name         | Quantity | Price | Product Value |
+----+----------------------+----------+-------+---------------+
| 7  | Matte Mania Lipstick | 1000     | 12.50 | 12500.00 $    |
+----+----------------------+----------+-------+---------------+
| 8  | Strawberry Lipstick  | 100      | 5.00  | 500.00 $      |
+----+----------------------+----------+-------+---------------+
####################

RemoveInventory, SkyLife, Lipstick
Inventory with name: Lipstick was removed
####################

ShowInventoryStock, Lipstick
Inventory doesn't exist
####################

FilterProductsBy, price, desc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Eye cream 24 h                   | 150      | 200.00 |
+----------------------------------+----------+--------+
| Hugo Boss Scent Perfume          | 1000     | 75.00  |
+----------------------------------+----------+--------+
| Dermacol Peach Flower Perfume    | 1000     | 50.00  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Dermacol Matte Mania Lipstick    | 1000     | 12.50  |
+----------------------------------+----------+--------+
| Cherry Lipstick                  | 60       | 5.00   |
+----------------------------------+----------+--------+
####################

FilterProductsBy, price, asc
+----------------------------------+----------+--------+
| Product Name                     | Quantity | Price  |
+----------------------------------+----------+--------+
| Cherry Lipstick                  | 60       | 5.00   |
+----------------------------------+----------+--------+
| Dermacol Matte Mania Lipstick    | 1000     | 12.50  |
+----------------------------------+----------+--------+
| Dermacol Gold Elexir Night Cream | 1000     | 29.90  |
+----------------------------------+----------+--------+
| Dermacol Peach Flower Perfume    | 1000     | 50.00  |
+----------------------------------+----------+--------+
| Hugo Boss Scent Perfume          | 1000     | 75.00  |
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
| Cherry Lipstick               | 60       | 5.00  |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Peach Flower Perfume | 1000     | 50.00 |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 1000     | 75.00 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume, asc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Dermacol Peach Flower Perfume | 1000     | 50.00 |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 1000     | 75.00 |
+-------------------------------+----------+-------+
####################

FilterProductsBy, name, perfume, desc
+-------------------------------+----------+-------+
| Product Name                  | Quantity | Price |
+-------------------------------+----------+-------+
| Hugo Boss Scent Perfume       | 1000     | 75.00 |
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
| Cherry Lipstick               | 60       | 5.00  |
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
| Cherry Lipstick               | 60       | 5.00  |
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
| 2  | Cherry Lipstick | Nivea | 60       | 5.00  |
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
| 4  | Hugo Boss Scent Perfume | Hugo Boss | 1000     | 75.00 |
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

ShowInventoryStock, Sky
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 90       | 8.00  | 720.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 60       | 5.00  | 300.00 $      |
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

ShowInventoryStock, Sky
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 90       | 8.00  | 720.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 60       | 5.00  | 300.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 3  | Dermacol Peach Flower Perfume | 1000     | 50.00 | 50000.00 $    |
+----+-------------------------------+----------+-------+---------------+
####################

BuyProduct, dermacol, strawberry lipstick, Sky, 60
You are about to buy strawberry lipstick, 60 piece's from it. Are you sure you want to continue?

Press yes or no!
yes
Successfully bought 60 pieces from strawberry lipstick product
####################

BuyProduct, Dermacol, peach flower Perfume, Sky, 260
You are about to buy peach flower Perfume, 260 piece's from it. Are you sure you want to continue?

Press yes or no!
no
Successfully bought 260 pieces from peach flower Perfume product
####################

ShowInventoryStock, Sky
The inventory contains a total of 3 products, including 0 creams, 1 perfumes, and 2 lipsticks.
+----+-------------------------------+----------+-------+---------------+
| ID | Product Name                  | Quantity | Price | Product Value |
+----+-------------------------------+----------+-------+---------------+
| 1  | Strawberry Lipstick           | 30       | 8.00  | 240.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 2  | Cherry Lipstick               | 60       | 5.00  | 300.00 $      |
+----+-------------------------------+----------+-------+---------------+
| 3  | Dermacol Peach Flower Perfume | 740      | 50.00 | 37000.00 $    |
+----+-------------------------------+----------+-------+---------------+
####################


````

Client Restrictions in the Inventory Management System
=====================================================

The inventory management system implements certain restrictions for clients to ensure limited access and capabilities compared to managers. These restrictions are in place to maintain control over critical functionalities, particularly product creation and inventory management. Here are the restrictions that apply to clients:

Clients cannot create or modify products:

- Clients are not authorized to use commands such as `CreateProduct` and `UpdateProduct`.
- Only managers have the privilege to create or modify products within the system.

Clients cannot manage inventories:

- Inventory management commands like `ACreateInventory` and `RemoveInventory` are disabled for clients.
- Clients are not allowed to manipulate the contents of inventories.
- Only managers can perform inventory management actions.

Please note that the following commands cannot be used by clients:

- CreateInventory (Command ID: 4)
- CreateCream (Command ID: 5)
- CreatePerfume (Command ID: 6)
- CreateLipstick (Command ID: 7)
- ChangeProductValue (Command ID: 8)
- RemoveProduct (Command ID: 9)
- ShowAllUsers (Command ID: 10)
- RemoveInventory (Command ID: 11)

Furthermore, the BuyProduct command is reserved for clients and cannot be used by managers.

`Note` These restrictions ensure a secure and controlled environment within the inventory management system, allowing clients and managers to fulfill their designated roles effectively.
## Project Hierarchy

The project consists of the following entities and interfaces:

### ICompany Interface

- `Name`: The name of the company.
- `Inventory`: A list of inventories associated with the company.
- `Users`: A list of users associated with the company.
- `CreateInventory(inventory)`: Creates a new inventory.
- `RemoveInventory(inventory)`: Removes an inventory.
- `AddMember(member)`: Adds a user as a member of the company.

### IInventory Interface

- `Name`: The name of the inventory.
- `Products`: A list of products in the inventory.
- `AddProduct(product)`: Adds a product to the inventory.
- `RemoveProduct(product)`: Removes a product from the inventory.

### IProduct Interface

- `Id`: The ID of the product.
- `Name`: The name of the product.
- `Brand`: The brand of the product.
- `Description`: The description of the product.
- `Price`: The price of the product.
- `Quantity`: The quantity of the product.
- `SetName(updatedProduct)`: Updates the name of the product.
- `SetPrice(newPrice)`: Updates the price of the product.
- `SetQuantity(quantity)`: Updates the quantity of the product.
- `ChangeId(id)`: Changes the ID of the product.

### IUser Interface

- `Username`: The username of the user.
- `FirstName`: The first name of the user.
- `LastName`: The last name of the user.
- `Password`: The password of the user.
- `Role`: The role of the user.
- `Inventory`: A list of inventories associated with the user.
- `AddInventory(inventory)`: Adds an inventory to the user.
- `RemoveInventory(inventory)`: Removes an inventory from the user.
- `SetPassword(newPassword)`: Updates the password of the user.
- `SetUsername(newUsername)`: Updates the username of the user.

## Credits

This project was created with the assistance of:

- Vasil Lyubenov, Email `[vasilliring@gmail.com]`

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
