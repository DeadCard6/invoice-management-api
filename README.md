# Invoice Management API

RESTful backend API to manage sales (**Invoices**), **Clients**, **Products**, and **Categories**, including **JWT-based authentication**.

## Architecture & Design Patterns

The solution is built using **Onion Architecture** and principles of **Domain-Driven Design (DDD)**:

- **Rich Domain Model:** Business logic (such as stock deduction, invoice total calculations, and status validation) is encapsulated directly inside the domain entities (`Invoice`, `Product`).
- **DTOs (Data Transfer Objects):** Used to isolate the domain layer from the API layer. The application layer maps entities to strongly typed `Response` and `Request` DTOs.
- **Repository Pattern & Unit of Work:** Abstracts data access, providing a clean contract for the Application services.
- **SQL Sequences:** Avoids race conditions during concurrent invoice creation by generating atomic invoice numbers at the database level.

### Project Structure
- `InvoiceManagementApi.Domain`: Core entities, interfaces, and domain exceptions.
- `InvoiceManagementApi.Application`: Application services, DTOs, and business orchestration.
- `InvoiceManagementApi.Infrastructure`: Entity Framework Core implementation, DbContext, Migrations, and Repositories.
- `InvoiceManagementApi.Authentication`: JWT Token generation and validation.
- `InvoiceManagementApi`: The ASP.NET Core Web API presentation layer.
- `InvoiceManagementApi.Tests`: xUnit project containing Domain and Application unit tests.

## Technologies Used

- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **xUnit, Moq, FluentAssertions** (for Unit Testing)
- **Swagger / OpenAPI** (for API documentation)

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (LocalDB or a full instance)

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/DeadCard6/invoice-management-api.git
   cd invoice-management-api
   ```

2. **Configure the Database Connection:**
   Update the `DefaultConnection` string in `appsettings.json` located in the main API project (`InvoiceManagementApi/appsettings.json`) if necessary. By default, it uses SQL Server LocalDB (`InvoiceManagementDb`).

3. **Apply Database Migrations:**
   Ensure your database is created, seeded, and updated to the latest schema:
   ```bash
   dotnet ef database update --project InvoiceManagementApi.Infrastructure/InvoiceManagementApi.Infrastructure.csproj --startup-project InvoiceManagementApi/InvoiceManagementApi.csproj
   ```
   *Note: Seed data is automatically applied during migration, populating initial Categories, Products, and a default Client.*

4. **Run the Application:**
   ```bash
   dotnet run --project InvoiceManagementApi/InvoiceManagementApi.csproj
   ```
   The API will start. You can explore and test the endpoints via Swagger UI at `https://localhost:<port>/swagger`.

## Running Tests

The solution includes a test project validating the Domain logic and Application services.

To run all unit tests:
```bash
dotnet test
```

## Authentication (JWT)

Most endpoints are secured via JWT (`[Authorize]`).
To test the API, register a user or log in via the `/api/Auth/login` endpoint to obtain a token, and pass it in the `Authorization` header as a `Bearer` token.
