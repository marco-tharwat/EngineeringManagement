Engineering Management System
An ASP.NET Core MVC CRUD application for managing Students, Professors, and Departments.

Features
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

Screenshots
<img width="1919" height="918" alt="Screenshot 2025-08-07 001235" src="https://github.com/user-attachments/assets/2c9ba670-b948-436c-92c8-21b368c10b4f" />
<img width="1919" height="923" alt="Screenshot 2025-08-07 121922" src="https://github.com/user-attachments/assets/7df8c453-d18b-4569-8bc3-9346ef5c9caf" />

- Home page
- Students CRUD
- Department details (showing related Students/Professors)

Technologies Used
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap

Getting Started

Prerequisites
- .NET 6 (or later)
- SQL Server (local instance or remote)

Setup
1) Clone the repository
   git clone https://github.com/marco-tharwat/engineering-management-system.git

2) Open the project in Visual Studio or VS Code

3) Update the connection string in ApplicationDbContext.cs to point to your SQL Server

4) Run database migrations
   dotnet ef database update

5) Run the application
   dotnet run

6) Navigate to https://localhost:5001 (or the port shown in console)

Quick Test (Manual)
1) Create a Department.
2) Create a Student and assign it to the Department.
3) Open Department details and verify related Students/Professors appear.
4) Try deleting the Department (should be blocked if related entities exist).

Project Structure
- Models/: Student.cs, Professor.cs, Department.cs
- Controllers/: StudentsController, ProfessorsController, DepartmentsController
- Views/: Razor views for CRUD operations
- Data/: ApplicationDbContext (Entity Framework Core context)

License
No license currently applied
