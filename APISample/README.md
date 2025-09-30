# C# REST API CRUD Example with Swagger

This sample demonstrates a simple ASP.NET Core Web API that exposes CRUD operations for a collection of books. It uses an in-memory repository and comes preconfigured with Swagger/OpenAPI support.

## Project Structure

```
APISample/
├── Contracts/
│   ├── CreateBookRequest.cs
│   └── UpdateBookRequest.cs
├── Controllers/
│   └── BooksController.cs
├── Models/
│   └── Book.cs
├── Program.cs
├── Repositories/
│   ├── IBookRepository.cs
│   └── InMemoryBookRepository.cs
├── Services/
│   └── BookService.cs
└── CrudSample.csproj
```

## Running the API

Make sure you have the .NET 8.0 SDK installed, then run:

```bash
cd APISample
dotnet restore
dotnet run
```

Navigate to `https://localhost:5001/swagger` (or the URL shown in the console) to explore and test the API endpoints with Swagger UI.

## API Overview

| Method | Endpoint          | Description         |
| ------ | ----------------- | ------------------- |
| GET    | `/api/books`      | Retrieve all books. |
| GET    | `/api/books/{id}` | Retrieve a book by ID. |
| POST   | `/api/books`      | Create a new book. |
| PUT    | `/api/books/{id}` | Update an existing book. |
| DELETE | `/api/books/{id}` | Delete a book. |

The sample starts with two predefined books in the in-memory repository, which makes it easy to experiment with the CRUD endpoints immediately.
