Full Stack Products & Orders System  
React + Redux Toolkit + .NET 10 API + Node.js + MongoDB

Overview

This project implements a two screen product ordering system using three independent components:

Client — React + Redux Toolkit  

- Displays categories and products(clicking on the category button opens product carts)  
- Retrieves data from .NET 10 API  
- Allows adding products to cart  
- Shows total price  
- Provides an order summary form  
- Sends order to Node.js backend

Server (Screen 1) — .NET 10 + SQL Server (PostgerSQL). Can select in Programm.cs SQL Server or PostgreSQL

- Provides categories  
- Provides products  
- Uses Entity Framework (code-first) 
- Stores product data in SQL Server (PostgreSQL) 
- Exposes REST API consumed by React

Server (Screen 2) — Node.js + MongoDB  

- Receives order from React  
- Saves order into MongoDB  
- Returns order ID  
- Uses Express + Mongoose  
- Database: `ordersdb`, collection: `orders` 

MongoDB was chosen as the NoSQL database (task allows MongoDB or Elasticsearch).

 Project Structure

 /DotNetProducts

├── client-ts/         React + Redux Toolkit

├── DotNetProductApi/           .NET 10 + SQL Server

└── orders-api/           Node.js + MongoDB


React Client (Screen 1 & 2)

- Category selection  
- Products filtering (by clicking on the Category button) 
- Add to cart  
- Cart total calculation  
- Continue → Order Summary  
- Order form (name, surname, email, address)  
- Send order to Node.js backend  
- Back to products button  

Start react
npm start

.NET 10 API (Screen 1)

Features

- SQL Server database  
- Entity Framework  
- Categories endpoint  
- Products endpoint  
- Used by React to display products

Start .Net API
dotnet run

Node.js + MongoDB (Screen 2)
 Features
- Express server  
- Mongoose models  
- POST /orders → save order  
- GET /orders/:id → retrieve order  
- Saves into MongoDB `ordersdb.orders`

 Start Node.js
 npm start
 
 MongoDB
Connect using MongoDB Compass:
mongodb://localhost:27017

Database: `ordersdb`  
Collection: `orders`

Full-Stack React + Redux Toolkit + .NET 10 API + Node.js + MongoDB 
can be run all together by batch file ClientRun.bat

@echo off

echo Starting React client...
cd client-ts
start cmd /k "npm start"

echo Starting Node.js orders API...
cd ../orders-api
start cmd /k "npm start"

echo Starting .NET Product API...
cd ../DotNetProductApi
start cmd /k "dotnet run"

echo All services started.
pause
 
 Example Order Document


_id
ObjectId('6a972551e93d43e16c9103c3')
firstName
"name"
lastName
"surname"
email
"aaa@bbb.com"
address
"Kfar-Saba"

items
Array (9)

0
Object (5)
productId
1
name
"קוטג"
price
4.5
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c4')

1
Object (5)
productId
2
name
"חלב 3%"
price
5
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c5')

2
Object (5)
productId
3
name
"שמנת חמוצה"
price
3.5
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c6')

3
Object (5)
productId
8
name
"שוקים"
price
12.99
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c7')

4
Object (5)
productId
9
name
"סלמון"
price
75.99
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c8')

5
Object (5)
productId
10
name
"בצל"
price
3.99
quantity
1
_id
ObjectId('6a972551e93d43e16c9103c9')

6
Object (5)
productId
11
name
"מנגו"
price
19.4
quantity
1
_id
ObjectId('6a972551e93d43e16c9103ca')

7
Object (5)
productId
4
name
"קרמים"
price
142.6
quantity
1
_id
ObjectId('6a972551e93d43e16c9103cb')

8
Object (5)
productId
5
name
"פרסטו ג'ל"
price
25.99
quantity
1
_id
ObjectId('6a972551e93d43e16c9103cc')
createdAt
ISODate('2026-09-01T19:19:45.883+00:00')
__v
0








