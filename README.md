# Inventory Management System

The Inventory Management System is an application built using object-oriented programming in C# that allows companies to manage their inventory and clients to shop for products

## Features

The system has the following features:

Create a company with multiple inventories
Create a manager to add products to the inventories
Create clients to shop for products
View the products in the inventory
Add products to the inventory
Remove products from the inventory
Update the quantity of products in the inventory
Calculate the total price of the products in the inventory
Allow clients to add products to their shopping cart
Allow clients to view their shopping cart
Allow clients to checkout and purchase the products in their shopping cart

## Usage
The Inventory Management System can be used as follows:

Create a company by specifying its name.
Add inventories to the company by specifying their names.
Create a manager for the company by specifying their name.
Add products to the inventory by specifying their name, price, and quantity.
View the products in the inventory.
Add products to the shopping cart by specifying the product and the quantity.
View the products in the shopping cart.
Checkout and purchase the products in the shopping cart.

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
