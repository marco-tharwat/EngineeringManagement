using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        ApplicationDbContext context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Department obj)
        {
            context.Departments.Add(obj);
        }

        public void Delete(int id)
        {
            var dept = GetById(id);
            context.Departments.Remove(dept);
        }

        public List<Department> GetAll()
        {
            return context.Departments.Include(d => d.Students).Include(d => d.Professors).ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.Include(d => d.Students).Include(d => d.Professors).FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            context.Departments.Update(obj);
        }
    }
}
