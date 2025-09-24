using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        ApplicationDbContext context = new();
        [HttpGet]
        public IActionResult Index()
        {
            var departments = context.Departments
                .Include(d => d.Students)
                .Include(d => d.Professors)
                .ToList();

            return View(departments);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = context.Departments.Include(d => d.Students).Include(d => d.Professors).FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                context.Departments.Update(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            ViewBag.AllProfessors = context.Professors.Where(p => p.DepartmentId == id).Count();
            ViewBag.AllStudents = context.Students.Where(s => s.DepartmentId == id).Count();
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = context.Departments.Find(id);
            ViewBag.AllProfessors = context.Professors.Where(p => p.DepartmentId == id).Count();
            ViewBag.AllStudents = context.Students.Where(s => s.DepartmentId == id).Count();
            if (department == null)
            {
                return NotFound();
            }

            try
            {
                context.Departments.Remove(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Couldn't delete, This department still has students or professors associated.");
                return View(department);
            }
        }

    }
}
