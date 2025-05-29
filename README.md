# Restaurant Reporting Management System

## Description
This project is built using **.NET 8 Web API** with **Clean Architecture** principles, and it incorporates various libraries to facilitate development, validation, and authentication.

## Technologies Used

- **.NET 8 Web API**: The project is built on the latest version of .NET, which provides a robust framework for building web APIs.
- **Clean Architecture**: A well-organized architecture pattern that separates concerns, improves maintainability, and enhances testability.
- **Mediator**: Used for managing communication between different components via the Mediator pattern, ensuring loose coupling.
- **AutoMapper**: Automatically maps objects between layers to reduce the need for manual mapping code.
- **FluentValidation**: Provides an easy and fluent interface for building validation rules for models.
- **EF Core 8.0.14**: Entity Framework Core is used as the ORM for data access, with version 8.0.14 for the latest improvements and features.
- **LINQ** Query for fetching Data.
- **Parameterize SQL Queries** to enhance the security of the App to protect from SQL injections.
- **Raw SQL Queries** implemented for complex queries.
- **SQL Transaction** for data integrity.
- **JWT Token Authentication**: Secure the API with **JSON Web Tokens (JWT)** for authenticating and authorizing users.
- **Role-Base Authentication** to access resources.
- **Docker** for easy deployment.
- **Caching** (In-Memory) for performance enhancement.

## Features

- Implemented Clean Architecture for scalable and maintainable code.
- Mediator pattern for decoupling business logic and handling requests and responses.
- FluentValidation for user input validation.
- JWT-based authentication for secure and efficient user login and authorization.
- Entity Framework Core 8.0.14 for ORM and database management.
