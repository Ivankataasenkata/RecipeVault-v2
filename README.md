# 🍲 RecipeVault

RecipeVault is a web application for collecting and organizing cooking recipes. Users can browse a styled catalog of recipes, see full details with ingredients and step-by-step instructions, and create, edit or delete recipes through validated forms.

Built as a final project for the C# Web course.

## Main features

- **Recipe catalog** – responsive card grid with photos, cuisine, difficulty badge (color-coded Easy/Medium/Hard) and preparation time
- **Full CRUD** for recipes – create, read, update and delete through the UI
- **Recipe details** – description, servings, ingredient list with quantities, and instructions
- **Cuisines** – every recipe belongs to a cuisine (Italian, Bulgarian, Asian seeded out of the box)
- **Validation** – server-side via data annotations and client-side via jQuery unobtrusive validation, with shared rules kept in a single constants class
- **Seed data** – the database is created with 5 sample recipes, 3 cuisines and 16 ingredients, so the app is ready to demo immediately

## Technologies

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core 10 (code-first with migrations and seed data)
- SQL Server (LocalDB by default)
- Bootstrap 5, Razor layout/partial views/sections
- jQuery validation for client-side checks

## Architecture

```
Controllers  →  IRecipeService (interface)  →  RecipeService  →  ApplicationDbContext  →  SQL Server
                     ↑ registered in DI (Program.cs)
ViewModels carry validation rules and shape the data for each view;
entities map the database tables (Recipe, Cuisine, Ingredient, RecipeIngredient with a composite key).
```

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (installed with Visual Studio, or via SQL Server Express)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

### Setup

```bash
git clone https://github.com/Ivankataasenkata/RecipeVault-v2.git
cd RecipeVault-v2/RecipeVault
dotnet ef database update   # creates the RecipeVault database and applies seed data
dotnet run                  # starts the app; open the printed localhost URL
```

No environment variables or credentials are required for local testing. The default connection string uses LocalDB with Windows authentication and is defined in `RecipeVault/appsettings.json`:

```
Server=(localdb)\mssqllocaldb;Database=RecipeVault;Trusted_Connection=True;
```

To use a different SQL Server instance, change the `DefaultConnection` string there and run `dotnet ef database update` again.

## Project structure

```
RecipeVault/
├── Common/            validation constants shared by entities and view models
├── Controllers/       HomeController, RecipeController (full CRUD)
├── Data/              ApplicationDbContext (composite key config + seed data)
├── Migrations/        EF Core migrations
├── Models/            entities: Recipe, Cuisine, Ingredient, RecipeIngredient, Difficulty enum
├── Services/          IRecipeService + RecipeService (business logic, injected via DI)
├── ViewModels/        form/list/details view models with validation attributes
└── Views/             Razor views: layout, partials (_RecipeCardPartial, _RecipeFormPartial), sections
```
