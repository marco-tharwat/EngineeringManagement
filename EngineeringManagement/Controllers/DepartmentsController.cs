using EngineeringManagement.Models;
using EngineeringManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        IRepository<Department> idr;
        IRepository<Student> isr;
        IRepository<Professor> ipr;

        public DepartmentsController(IRepository<Department> idr, IRepository<Student> isr, IRepository<Professor> ipr)
        {
            this.idr = idr;
            this.isr = isr;
            this.ipr = ipr;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = idr.GetAll();
            return View("Index", departments);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var dept = idr.GetById(id);
            return dept == null ? NotFound() : View("Details", dept);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                idr.Add(department);
                idr.Save();
                return RedirectToAction("Index");
            }
            return View("Create", department);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = idr.GetById(id);
            return dept == null ? NotFound() : View("Edit", dept);
        }
        [HttpPost]
        public IActionResult Edit(int id, Department department)
        {
            if (id != department.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                idr.Update(department);
                idr.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = idr.GetById(id);
            ViewBag.AllProfessors = department.Professors.Count();
            ViewBag.AllStudents = department.Students.Count();
            if (department == null)
            {
                return NotFound();
            }
            return View("Delete", department);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = idr.GetById(id);
            ViewBag.AllProfessors = department.Professors.Count();
            ViewBag.AllStudents = department.Students.Count();
            if (department == null)
            {
                return NotFound();
            }

            if (department.Professors.Count() != 0 || department.Students.Count() != 0)
            {
                ModelState.AddModelError("", "Couldn't delete, This department still has students or professors associated.");
                return View("Delete", department);
            }
            idr.Delete(id);
            idr.Save();
            return RedirectToAction("Index");
        }

    }
}
