using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace Mvc_WebApp_Level2.Controllers
{
    public class CourseController : Controller
    {
        private readonly IclsCourse model;
        private readonly IclsDepartment dept;
        private readonly IclsInstructor inctor;

        public CourseController(IclsCourse _model, IclsDepartment _dept, IclsInstructor _inctor)
        {
            model = _model;
            dept = _dept;
            inctor = _inctor;
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

        [Authorize]
        public IActionResult Add(int id)
        {
            ViewBag.DeptsIds = (from dept in dept.GetAll()
                               select new { dept.Id, dept.Name }).ToList();
            ViewBag.InctorsIds = (from inctor in inctor.GetAll()
                                 select new { inctor.Id, inctor.Name }).ToList();
            if (id == 0)
                return View(new Course());
            return View(model.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
            ViewBag.DeptsIds = (from dept in dept.GetAll()
                                select new { dept.Id, dept.Name }).ToList();
            ViewBag.InctorsIds = (from inctor in inctor.GetAll()
                                  select new { inctor.Id, inctor.Name }).ToList();
            return View("Add", course);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RelativeInfo(int deptId)
        {
            return PartialView("List", model.GetRelative(deptId));
        }
    }
}
