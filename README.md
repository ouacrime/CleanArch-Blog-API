
# Blog API with Clean Architecture

This project is a simple CRUD API for managing blog posts, implemented using Clean Architecture principles and Domain-Driven Design (DDD) methodology.

## Overview

The Blog API is built with a focus on maintainability, scalability, and testability. It follows the principles of Clean Architecture, which promotes separation of concerns and modularity, making the codebase easy to understand and maintain.

## Features

- **Create, Read, Update, Delete (CRUD) operations**: Allows users to perform basic CRUD operations on blog posts.
- **Clean Architecture**: Separates the application into layers (Domain, Application, Infrastructure, Presentation) to ensure loose coupling and high cohesion.
- **Domain-Driven Design (DDD)**: Uses DDD principles to model the domain logic and entities, keeping the business logic isolated from infrastructure concerns.
- **Dependency Injection (DI)**: Utilizes DI to manage dependencies and promote testability.
- **Unit Tests**: Includes unit tests for core business logic to ensure correctness and reliability.
- **Swagger Documentation**: Provides Swagger documentation for easy API exploration and testing.

## Technologies Used

- **ASP.NET Core**: Framework for building APIs using C#.
- **Entity Framework Core**: ORM for database access.
- **AutoMapper**: Library for object-to-object mapping.
- **FluentValidation**: Library for input validation.
- **Swashbuckle.AspNetCore**: Library for generating Swagger documentation.
- **xUnit**: Testing framework for unit tests.

## Getting Started

To run the project locally, follow these steps:

1. **Clone the repository**: `git clone [repository URL]`
2. **Navigate to the project directory**: `cd BlogAPI`
3. **Install dependencies**: `dotnet restore`
4. **Run the application
