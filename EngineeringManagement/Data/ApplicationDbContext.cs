using EngineeringManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=Marco\\MSSQLSERVER01;Database=EngineeringManagement;TrustServerCertificate=True;Trusted_Connection=True");
        //}
    }
}

