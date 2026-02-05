using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Student obj)
        {
            context.Students.Add(obj);
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            context.Students.Remove(student);
        }

        public List<Student> GetAll()
        {
            return context.Students.Include(s => s.Department).ToList();
        }

        public Student GetById(int id)
        {
            return context.Students.Include(s => s.Department).FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Student obj)
        {
            context.Students.Update(obj);
        }
    }
}
