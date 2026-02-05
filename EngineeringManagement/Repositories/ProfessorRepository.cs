using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Repositories
{
    public class ProfessorRepository : IRepository<Professor>
    {
        ApplicationDbContext context;
        public ProfessorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Professor obj)
        {
            context.Professors.Add(obj);
        }

        public void Delete(int id)
        {
            var prof = GetById(id);
            context.Professors.Remove(prof);
        }

        public List<Professor> GetAll()
        {
            return context.Professors.Include(p => p.Department).ToList();
        }

        public Professor GetById(int id)
        {
            return context.Professors.Include(p => p.Department).FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Professor obj)
        {
            context.Professors.Update(obj);
        }
    }
}
