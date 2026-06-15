# WebApiSample

A sample ASP.NET Core Web API project.

## Technologies

- ASP.NET Core 9
- Entity Framework Core
- SQL Server
- Swagger
- API Versioning

## Features

- CRUD Operations
- Repository Pattern
- Dependency Injection
- Swagger Documentation
- API Versioning
- SQL Server Integration

## Getting Started

### Clone Repository

```bash
git clone https://github.com/USERNAME/WebApiSample.git
cd WebApiSample
```

### Restore Packages

```bash
dotnet restore
```

### Update Connection String

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DbApiSample;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### Run Migrations

```bash
dotnet ef database update
```

### Run Project

```bash
dotnet run
```

or

```bash
dotnet watch run
```

## Swagger

```
https://localhost:xxxx/swagger
```

## API Versioning

Examples:

```
GET /api/products?api-version=1.0
```

Header:

```
X-Version: 1.0
```

## Project Structure

```
Controllers/
Models/
Repository/
DatabaseContext/
Migrations/
```

## Author

Rouhollah Asadi
