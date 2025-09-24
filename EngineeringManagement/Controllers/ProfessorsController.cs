using EngineeringManagement.Data;
using EngineeringManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EngineeringManagement.Controllers
{
    public class ProfessorsController : Controller
    {
        ApplicationDbContext context = new();
        // GET: ProfessorsController
        [HttpGet]
        public ActionResult Index()
        {
            var professors = context.Professors.Include(p => p.Department).ToList();
            return View(professors);
        }

        // GET: ProfessorsController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var professor = context.Professors.Include(p => p.Department).FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // GET: ProfessorsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name");
            return View();
        }

        // POST: ProfessorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                context.Professors.Add(professor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            // Reload departments for dropdown if validation fails
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", professor.DepartmentId);
            return View(professor);
        }

        // GET: ProfessorsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var professor = context.Professors.Include(p => p.Department).FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", professor.DepartmentId);
            return View(professor);
        }

        // POST: ProfessorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                context.Professors.Update(professor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", professor.DepartmentId);
            return View(professor);
        }

        // GET: ProfessorsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Professor? professor = context.Professors.Include(p => p.Department).FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }
        // POST: ProfessorsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor? professor = context.Professors.Include(p => p.Department).FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return NotFound();
            }
            context.Professors.Remove(professor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
