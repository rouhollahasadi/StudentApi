# WebApiSample

A sample ASP.NET Core Web API project for managing students, demonstrating CRUD operations, JWT Authentication, API Versioning, and Swagger documentation.

---

# Technologies

* ASP.NET Core 9
* Entity Framework Core
* SQL Server
* Swagger (OpenAPI)
* JWT Authentication
* API Versioning
* Dependency Injection
* Repository Pattern

---

# Features

* Student CRUD Operations
* Repository Pattern
* Dependency Injection (DI)
* Entity Framework Core
* SQL Server Integration
* Swagger Documentation
* JWT Authentication & Authorization
* API Versioning
* XML Comments Documentation

---

# Project Structure

```text
Controllers/
├── StudentController.cs
├── TokenController.cs

Models/
├── Student.cs
├── ViewModels/
├── Repository/
├── DatabaseContext/

Migrations/

Program.cs
appsettings.json
```

---

# Getting Started

## Clone Repository

```bash
git clone https://github.com/USERNAME/WebApiSample.git
cd WebApiSample
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Update Connection String

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=DbApiSample;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## Configure JWT

Update JWT settings inside `appsettings.json`:

```json
{
  "JsonWebTokenConfig": {
    "Key": "YourSuperSecretKeyHere1234567890",
    "Issuer": "localhost",
    "Audience": "localhost",
    "ExpireTime": "60"
  }
}
```

---

## Run Database Migration

Create migration:

```bash
dotnet ef migrations add InitialCreate
```

Apply migration:

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet run
```

or

```bash
dotnet watch run
```

---

# Swagger

After running the application:

```text
https://localhost:xxxx/swagger
```

---

# Authentication

## Generate JWT Token

Request:

```http
POST /api/token/generate
```

Body:

```json
{
  "username": "admin",
  "password": "123"
}
```

Response:

```json
{
  "token": "eyJhbGc...",
  "expiresIn": "2026-06-17T10:30:00",
  "tokenType": "Bearer"
}
```

---

## Use Token in Swagger

1. Click the **Authorize** button.
2. Enter the token in the following format:

```text
Bearer eyJhbGc...
```

3. Call secured endpoints.

---

# Student Endpoints

## Get All Students

```http
GET /api/student
```

Requires Authentication: ✅

---

## Get Student By Id

```http
GET /api/student/{id}
```

Requires Authentication: ✅

---

## Create Student

```http
POST /api/student
```

Requires Authentication: ✅

Example:

```json
{
  "firstName": "Ali",
  "lastName": "Ahmadi",
  "age": 20
}
```

---

## Update Student

```http
PUT /api/student
```

Requires Authentication: ✅

---

## Delete Student

```http
DELETE /api/student/{id}
```

Requires Authentication: ✅

---

## Public Endpoint

```http
GET /api/student/public
```

Requires Authentication: ❌

---

# API Versioning

Query String:

```http
GET /api/student?api-version=1.0
```

Header:

```http
X-Version: 1.0
```

Media Type:

```http
Accept: application/json;ver=1.0
```

---

# Packages Used

```bash
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspNetCore
Asp.Versioning.Mvc
Microsoft.AspNetCore.Authentication.JwtBearer
```

---

# Author

**Rouhollah Asadi**

ASP.NET Core Developer
