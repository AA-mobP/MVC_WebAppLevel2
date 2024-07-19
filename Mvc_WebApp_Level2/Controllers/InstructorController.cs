using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;

namespace MVC_WebAppLevel2.Controllers
{
    public class InstructorController : Controller
    {
        private static clsInstructor model = new();

        public IActionResult Index()
        {
            model = new();
            return View("List", model.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            Instructor instructor = model.GetOne(id);

            ViewBag.Previous = model.GetPreviousId();
            ViewBag.Next = model.GetNextId();

            return View(instructor);
        }

        public IActionResult Add(int id)
        {
            ViewBag.DeptsIds = (from dept in new AppDbContext().departments
                               select new { dept.Id, dept.Name }).ToList();
            if (id == 0)
                return View(new Instructor());
            return View(model.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                if (instructor.Id == 0)
                    model.Add(instructor);
                else
                    model.Edit(instructor);
                return RedirectToAction("Index");
            }
            ViewBag.DeptsIds = (from dept in new AppDbContext().departments
                                select new { dept.Id, dept.Name }).ToList();
            return View("Add", instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            model.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult RelativeInfo(int deptId)
        {
            return PartialView("List", model.GetRelative(deptId));
        }
    }
}
