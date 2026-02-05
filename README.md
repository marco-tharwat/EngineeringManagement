ENGINEERING MANAGEMENT SYSTEM
============================

An ASP.NET Core MVC CRUD application for managing Students, Professors, and Departments.


FEATURES
--------

- Three models: Student, Professor, Department
- Full CRUD operations using Controllers and Razor Views
- Entity Framework Core + SQL Server for data storage
- Repository Pattern + Dependency Injection (controllers depend on repository interfaces)
- One-to-many relationships:
  - Departments → Students
  - Departments → Professors
- Validation attributes applied in models:
  - Required, MinLength, MaxLength, Range
- Dropdown lists (ViewBag + SelectList) to assign Students/Professors to Departments
- Department Details page displays related Students and Professors
- Delete restriction:
  - Departments cannot be deleted if they have Students or Professors associated
- Bootstrap used for table, form, and button styling
- Home page with links to manage each module


SCREENSHOTS
-----------

Home page
Students CRUD
Department index 


- docs/images/Home index.png
- docs/images/Departments index.png
- docs/images/Department delete.png


TECHNOLOGIES USED
-----------------

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap


GETTING STARTED
---------------

PREREQUISITES
- .NET 6 (or later)
- SQL Server (LocalDB or SQL Server instance)

SETUP
1) Clone the repository:
   git clone https://github.com/marco-tharwat/engineering-management-system.git

2) Open the project in Visual Studio or VS Code.

3) Update the connection string in appsettings.json:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=...;Database=...;Trusted_Connection=True;TrustServerCertificate=True"
     }
   }

4) Apply migrations / create the database:
   dotnet ef database update

5) Run the application:
   dotnet run

6) Navigate to:
   https://localhost:5001
   (or the port shown in the console)


QUICK TEST (MANUAL)
-------------------

1) Create a Department.
2) Create a Student and assign it to the Department.
3) Open Department Details and verify related Students/Professors appear.
4) Try deleting the Department (should be blocked if related entities exist).


LICENSE
-------

No license currently applied.
