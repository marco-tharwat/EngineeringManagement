# Engineering Management System

An ASP.NET Core MVC CRUD application for managing Students, Professors, and Departments.

## Features
- Three models: Student, Professor, Department
- Full CRUD operations with Controllers and Razor Views
- Entity Framework Core with SQL Server for data storage
- One-to-many relationships (Departments → Students, Departments → Professors)
- Validation attributes applied in models (Required, MinLength, MaxLength, Range)
- Dropdown lists (ViewBag + SelectList) to assign Students and Professors to Departments
- Related Students and Professors displayed in Department details
- Delete restriction: Departments cannot be deleted if they have Students or Professors associated
- Bootstrap used for simple table, form, and button styling
- Home page with links to manage each module

## Technologies Used
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap

## Getting Started

### Prerequisites
- .NET 6 (or later)
- SQL Server (local instance or remote)

### Setup
1. Clone the repository
   git clone https://github.com/marco-tharwat/engineering-management-system.git
2. Open the project in Visual Studio or VS Code
3. Update the connection string in ApplicationDbContext.cs or appsettings.json to point to your SQL Server
4. Run database migrations
   dotnet ef database update
5. Run the application
   dotnet run
6. Navigate to https://localhost:5001 (or the port shown in console)

## Project Structure
- Models/: Student.cs, Professor.cs, Department.cs
- Controllers/: StudentsController, ProfessorsController, DepartmentsController
- Views/: Razor views for CRUD operations
- Data/: ApplicationDbContext (Entity Framework Core context)

## License
This project was created as a learning project. No license currently applied.
