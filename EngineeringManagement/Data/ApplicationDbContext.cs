using EngineeringManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=Eng01\\MSSQLSERVER01;Database=EngineeringManagement;TrustServerCertificate=True;Trusted_Connection=True");
        }
    }
}

