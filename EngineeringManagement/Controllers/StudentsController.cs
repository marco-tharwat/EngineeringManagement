using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Controllers
{
    public class StudentsController : Controller
    {
        ApplicationDbContext context = new();

        [HttpGet]
        public IActionResult Index()
        {
            var students = context.Students.Include(s => s.Department).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            // Reload departments for dropdown if validation fails
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", student.DepartmentId);
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", student.DepartmentId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Added for consistency
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", student.DepartmentId);
            return View(student);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = context.Students
                .Include(s => s.Department)  // Make sure Department is included
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}