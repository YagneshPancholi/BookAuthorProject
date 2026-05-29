# BookAuthorProject

A full-stack Book & Author management system with three client surfaces: an ASP.NET Core REST API, a WPF MVVM desktop application, and an Angular web application.

---

## Table of Contents

- [Architecture Overview](#architecture-overview)
- [Project Structure](#project-structure)
- [Technology Stack](#technology-stack)
- [Backend (ASP.NET Core API)](#backend-aspnet-core-api)
  - [API Endpoints](#api-endpoints)
  - [Domain Models](#domain-models)
  - [Database](#database)
- [WPF Desktop App](#wpf-desktop-app)
- [Angular Web App](#angular-web-app)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Running the API](#running-the-api)
  - [Running the Angular App](#running-the-angular-app)
  - [Running the WPF App](#running-the-wpf-app)

---

## Architecture Overview

```
┌─────────────────────┐     ┌─────────────────────┐
│   Angular Web App   │     │   WPF Desktop App   │
│   (FrontEnd/)       │     │  (Project1WpfMVVM/) │
└────────┬────────────┘     └──────────┬──────────┘
         │                             │
         │        HTTP REST            │
         └──────────────┬──────────────┘
                        ▼
           ┌────────────────────────┐
           │  ASP.NET Core Web API  │
           │   localhost:7034       │
           │  (BackEnd/Project1/)   │
           └────────────┬───────────┘
                        │  Entity Framework Core
                        ▼
           ┌────────────────────────┐
           │  SQL Server Express    │
           │  Database: Project2    │
           └────────────────────────┘
```

Both clients share the same REST API. No authentication is currently implemented — all endpoints are open.

---

## Project Structure

```
BookAuthorProject/
├── BackEnd/                        # ASP.NET Core solution
│   ├── Project1/                   # API layer (controllers, Program.cs)
│   ├── Application/                # Interfaces (repositories) + DTOs
│   ├── Domain/                     # Domain entities (pure, no dependencies)
│   ├── Database/                   # DbContext
│   ├── Infrastructure/             # EF Core service implementations + migrations
│   └── Models/                     # Shared models
├── FrontEnd/
│   └── Project1/                   # Angular web application
├── Project1WpfMVVM/                # WPF MVVM desktop application
└── thoughts/
    └── research/                   # Codebase research documents
```

**Clean Architecture layer order (dependency direction):**

```
API → Application + Infrastructure → Domain
```

---

## Technology Stack

| Layer             | Technology                      | Version         |
| ----------------- | ------------------------------- | --------------- |
| REST API          | ASP.NET Core                    | net8.0          |
| ORM               | Entity Framework Core           | 7.0.10          |
| Database          | SQL Server Express              | —               |
| Desktop Client    | WPF + MVVM                      | net10.0-windows |
| Web Client        | Angular                         | 15+             |
| Web Styling       | Tailwind CSS + Angular Material | —               |
| Web UI Components | Kendo UI for Angular            | —               |
| WPF UI Components | Extended WPF Toolkit            | 4.5.1           |
| API Docs          | Swagger / Swashbuckle           | 6.5.0           |

---

## Backend (ASP.NET Core API)

### API Endpoints

All routes follow the pattern `api/[controller]/[action]`.

#### Authors — `api/Author`

| Method | Endpoint                  | Description                     |
| ------ | ------------------------- | ------------------------------- |
| GET    | `/GetAllAuthors`          | Returns all authors             |
| GET    | `/GetAuthorByName/{name}` | Returns a single author by name |
| POST   | `/AddAuthor`              | Creates a new author            |
| PUT    | `/UpdateAuthor/{name}`    | Updates an existing author      |
| DELETE | `/DeleteAuthor/{name}`    | Deletes an author by name       |

#### Books — `api/Book`

| Method | Endpoint                    | Description                   |
| ------ | --------------------------- | ----------------------------- |
| GET    | `/GetAllBooks`              | Returns all books             |
| GET    | `/GetBookByName/{bookName}` | Returns a single book by name |
| POST   | `/AddBook`                  | Creates a new book            |
| PUT    | `/UpdateBook/{bookName}`    | Updates an existing book      |
| DELETE | `/DeleteBook/{bookName}`    | Deletes a book by name        |

#### Genres — `api/Genre`

| Method | Endpoint              | Description         |
| ------ | --------------------- | ------------------- |
| GET    | `/GetAllGenres`       | Returns all genres  |
| POST   | `/AddGenre`           | Creates a new genre |
| DELETE | `/DeleteGenre/{name}` | Deletes a genre     |

#### Publishers — `api/Publisher`

| Method | Endpoint                  | Description             |
| ------ | ------------------------- | ----------------------- |
| GET    | `/GetAllPublishers`       | Returns all publishers  |
| POST   | `/AddPublisher`           | Creates a new publisher |
| DELETE | `/DeletePublisher/{name}` | Deletes a publisher     |

Swagger UI is available at `https://localhost:7034/swagger` when running in development.

---

### Domain Models

```
Author         Book              Genre           Publisher
──────         ────              ─────           ─────────
Id             Id                Id              Id
AuthorName     BookName          GenreName       PublisherName
BirthDate      Price
Email          ── many-to-many ──▶ Author
Education      ── many-to-many ──▶ Genre
               ── many-to-many ──▶ Publisher
```

Junction tables: `BookAuthor`, `BookGenre`, `BookPublisher`

All entities inherit from `BaseModel` which adds `CreationDateTime`.

---

### Database

- **Provider:** SQL Server Express
- **Server:** `Y940876-W10\SQLEXPRESS`
- **Database:** `Project2`
- **Migrations:** `BackEnd/Infrastructure/Migrations/`

Some author operations use stored procedures deployed to the database:

- `spAuthors_GetAllAuthors`
- `spAuthors_GetAuthorByName`
- `spAuthors_DeleteAuthorByName`

---

## WPF Desktop App

Located in `Project1WpfMVVM/`. Targets `net10.0-windows`.

**Pattern:** MVVM with `ObservableObject` (INotifyPropertyChanged) base class.

**Navigation:** A `Navigator` service holds `CurrentViewModel`. Switching views is done via `UpdateCurrentViewModelCommand` using a `ViewTypes` enum (Home, Authors, AddAuthor, EditAuthor, Books, AddBook, EditBook, Genres, Publishers).

**ViewModels:**

| ViewModel             | Purpose                               |
| --------------------- | ------------------------------------- |
| `MainViewModel`       | Root VM; initializes Navigator        |
| `HomeViewModel`       | Dashboard/welcome screen              |
| `AuthorsViewModel`    | Author list with delete/edit commands |
| `AddAuthorViewModel`  | Author creation form                  |
| `EditAuthorViewModel` | Author edit form                      |
| `BooksViewModel`      | Book list with delete/edit commands   |
| `AddBookViewModel`    | Book creation form                    |
| `EditBookViewModel`   | Book edit form                        |
| `GenresViewModel`     | Genre list                            |
| `PublishersViewModel` | Publisher list                        |

**Services** (`Services/`): Each entity has a `*ServiceWpf.cs` class that calls the REST API using `HttpClient` + `Newtonsoft.Json`.

**Commands** (`Commands/`): `AddAuthorCommand`, `DeleteAuthorCommand`, `EditAuthorCommand`, `AddBookCommand`, `DeleteBookCommand`, `EditBookCommand`, `UpdateCurrentViewModelCommand`.

---

## Angular Web App

Located in `FrontEnd/Project1/`.

**Module structure:** Feature modules per entity — `AuthorsModule`, `BooksModule`, `GenresModule`, `PublishersModule`.

**Routing:**

| Path                | Component          |
| ------------------- | ------------------ |
| `/Author`           | Author list        |
| `/addAuthor`        | Add author form    |
| `/editAuthor/:name` | Edit author form   |
| `/Book`             | Book list          |
| `/addBook`          | Add book form      |
| `/editBook/:name`   | Edit book form     |
| `/Genre`            | Genre list         |
| `/addGenre`         | Add genre form     |
| `/Publisher`        | Publisher list     |
| `/addPublisher`     | Add publisher form |

**Services** use Angular's `HttpClient` and return RxJS `Observable<T>`. The API base URL is defined in `src/app/DataTypes.ts`.

---

## Getting Started

### Prerequisites

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download) (or 8.0+ for the BackEnd only)
- [SQL Server Express](https://www.microsoft.com/sql-server/sql-server-downloads)
- [Node.js 18+](https://nodejs.org/) and [Angular CLI](https://angular.io/cli)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) (for net10.0-windows WPF project)

### Running the API

```powershell
cd BackEnd/Project1
dotnet restore
dotnet ef database update --project ../Infrastructure
dotnet run
```

The API will be available at `https://localhost:7034`. Swagger UI at `https://localhost:7034/swagger`.

> **Note:** Ensure SQL Server is running and the stored procedures (`spAuthors_*`) are deployed to the `Project2` database.

### Running the Angular App

```powershell
cd FrontEnd/Project1
npm install
ng serve
```

The app will be available at `http://localhost:4200`. The API must be running first.

### Running the WPF App

Open `Project1WpfMVVM/Project1WpfMVVM.sln` in Visual Studio 2026 and press **F5**, or:

```powershell
cd Project1WpfMVVM
dotnet run
```

The API must be running at `https://localhost:7034` before launching the WPF app.
