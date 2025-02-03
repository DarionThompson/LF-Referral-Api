# Referral-Api

A .Net Core REST API for generating and managing referral links. Supports SQLLite for
persisence, Entity Framework Core for migrations, and includes unit Testing

--- 

# Prerequuisites
Ensure you have the following installed: 
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

# The Repository 

- [Github](https://github.com/DarionThompson/LF-Referral-Api)

# Install Dependies 
Run the following command in the project root: 
dotnet restore
dotnet build 


# Run the API
dotnet run --project ReferralService.API

The API Should be running at: 
http://localhost:5084/api/Referral/

Full API Documentation is available in **`referral-api.yaml`** (OpenAPI 3.0) in the root of the project

---

# Running Tests 
The project uses xunit , moq, and Fluent Assertions for unit tests

dotnet test

---

## Packages Used

[AutoMapper](https://automapper.org/) | Object Mapping |
[Moq](https://github.com/moq/moq4) | Mocking for Unit Tests |
[FluentAssertions](https://fluentassertions.com/) | Fluent Syntax for Testing |
[Microsoft.EntityFrameworkCore.Sqlite](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/) | SQLite Database Provider |
