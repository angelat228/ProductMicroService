Product Microservice API

This is a simple ASP.NET Core Web API for managing products. It supports basic CRUD operations (Create, Read, Update, Delete).

Features:
List all products (GET /products)
Get a product by ID (GET /products/{id})
Create a new product (POST /products)
Update an existing product (PUT /products/{id})
Delete a product (DELETE /products/{id})
Unit-tested repository layer using xUnit.
Run the API
Open the project in Visual Studio.
The default launch URL is set to Swagger:
HTTP: http://localhost:5079/swagger
HTTPS: https://localhost:7087/swagger
To access the products endpoint directly:
GET    /products
GET    /products/{id}
POST   /products
PUT    /products/{id}
DELETE /products/{id}
Seed Data
The API automatically seeds the database on first run
Run Unit Tests
The repository layer is tested with xUnit.
Tests cover:
Adding a product, Getting a product by ID, Updating a product, Deleting a product.
