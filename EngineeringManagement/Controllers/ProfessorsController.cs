using EngineeringManagement.Models;
using EngineeringManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EngineeringManagement.Controllers
{
    public class ProfessorsController : Controller
    {
        // GET: ProfessorsController
        IRepository<Professor> ipr;
        IRepository<Department> idr;
        public ProfessorsController(IRepository<Professor> ipr, IRepository<Department> idr)
        {
            this.ipr = ipr;
            this.idr = idr;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var professors = ipr.GetAll();
            return View("Index", professors);
        }

        // GET: ProfessorsController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var professor = ipr.GetById(id);
            return professor == null ? NotFound() : View("Details", professor);
        }

        // GET: ProfessorsController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name");
            return View("Create");
        }

        // POST: ProfessorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                ipr.Add(professor);
                ipr.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", professor.DepartmentId);
            return View("Create", professor);
        }

        // GET: ProfessorsController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var professor = ipr.GetById(id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", professor.DepartmentId);
            return View("Edit", professor);
        }

        // POST: ProfessorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                ipr.Update(professor);
                ipr.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = new SelectList(idr.GetAll(), "Id", "Name", professor.DepartmentId);
            return View("Edit", professor);
        }

        // GET: ProfessorsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Professor professor = ipr.GetById(id);
            return professor == null ? NotFound() : View("Delete", professor);
        }
        // POST: ProfessorsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor? professor = ipr.GetById(id);
            if (professor == null)
            {
                return NotFound();
            }

            ipr.Delete(id);
            ipr.Save();
            return RedirectToAction("Index");
        }
    }
}
