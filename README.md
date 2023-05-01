# Inventory Management System

The Inventory Management System is an application built using object-oriented programming in C# that allows companies to manage their inventory and clients to shop for products

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

## Usage
The Inventory Management System can be used as follows:

1. Create a company by specifying its name.
2. Add inventories to the company by specifying their names.
3. Create a manager for the company by specifying their name.
4. Add products to the inventory by specifying their name, price, and quantity.
5. View the products in the inventory.
6. Add products to the shopping cart by specifying the product and the quantity.
7. View the products in the shopping cart.
8. Checkout and purchase the products in the shopping cart.

## Project Hierarchy and Entity Descriptions

| Object      | Properties | Methods          | Relationships                                         |
|-------------|------------|------------------|-------------------------------------------------------|
| Company     | Name       | CreateInventory  | Has a list of Users and Inventories                   |
|             |            | CreateManager    |                                                       |
|             |            |                  |                                                       |
| Inventory   | Name       | AddProduct       | Belongs to a Company                                  |
|             |            | RemoveProduct    | Has a list of Products                                |
|             |            | UpdateQuantity   |                                                       |
|             |            | CalculateTotal   |                                                       |
|             |            |                  |                                                       |
| User        | Name       | AddProductToCart | Belongs to a Company                                  |
| (Manager)   |            | RemoveProduct    |                                                       |
|             |            | UpdateProduct    |                                                       |
|             |            |                  |                                                       |
| User        | Name       | AddProductToCart | Belongs to a Company                                  |
| (Client)    |            | RemoveProduct    | Has a list of Products in their cart                  |
|             |            | UpdateProduct    |                                                       |
|             |            | Checkout         |                                                       |
|             |            |                  |                                                       |
| Product     | Name       |                  | Belongs to an Inventory and can be in a User's cart   |
|             | Price      |                  |                                                       |
|             | Quantity   |                  |                                                       |
