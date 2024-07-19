using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;

namespace Mvc_WebApp_Level2.Controllers
{
    public class CourseController : Controller
    {
        //Course Model
        private static clsCourse model = new();

        public IActionResult Index()
        {
            model = new();
            return View("List", model.GetAll());
        }

        public IActionResult Details(int id) //Details
        {
            Course course = model.GetOne(id);
            
            ViewBag.Next = model.GetNextId();
            ViewBag.Previous = model.GetPreviousId();

            return View(course);
        }

        public IActionResult Add(int id)
        {
            AppDbContext context = new();
            ViewBag.DeptsIds = (from dept in context.departments
                               select new { dept.Id, dept.Name }).ToList();
            ViewBag.InctorsIds = (from inctor in context.instructors
                                 select new { inctor.Id, inctor.Name }).ToList();
            if (id == 0)
                return View(new Course());
            return View(model.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.Id == 0)
                    model.Add(course);
                else
                    model.Edit(course);
                return RedirectToAction("Index");
            }
            AppDbContext context = new();
            ViewBag.DeptsIds = (from dept in context.departments
                                select new { dept.Id, dept.Name }).ToList();
            ViewBag.InctorsIds = (from inctor in context.instructors
                                  select new { inctor.Id, inctor.Name }).ToList();
            return View("Add", course);
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
