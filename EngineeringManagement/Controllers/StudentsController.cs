using EngineeringManagement.Models;
using EngineeringManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EngineeringManagement.Controllers
{
    public class StudentsController : Controller
    {
        IRepository<Department> idr;
        IRepository<Student> isr;

        public StudentsController(IRepository<Department> idr, IRepository<Student> isr)
        {
            this.idr = idr;
            this.isr = isr;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = isr.GetAll();
            return View("Index", students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = isr.GetById(id);
            return student == null ? NotFound() : View("Details", student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name");
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                isr.Add(student);
                isr.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", student.DepartmentId);
            return View("Create", student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = isr.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", student.DepartmentId);
            return View("Edit", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                isr.Update(student);
                isr.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", student.DepartmentId);
            return View("Edit", student);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = isr.GetById(id);
            return student == null ? NotFound() : View("Delete", student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = isr.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            isr.Delete(id);
            isr.Save();
            return RedirectToAction("Index");
        }
    }
}