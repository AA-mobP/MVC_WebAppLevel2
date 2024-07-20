using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace Mvc_WebApp_Level2.Controllers
{
    public class CourseController : Controller
    {
        IclsCourse model;

        public CourseController(IclsCourse _model)
        {
            model = _model;
        }

        public IActionResult Index()
        {
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
