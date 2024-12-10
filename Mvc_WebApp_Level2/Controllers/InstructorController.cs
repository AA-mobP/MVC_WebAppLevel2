using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace MVC_WebAppLevel2.Controllers
{
    public class InstructorController : Controller
    {
        IclsInstructor model;
        private readonly IclsDepartment dept;

        public InstructorController(IclsInstructor _model, IclsDepartment _dept)
        {
            model = _model;
            dept = _dept;
        }

        public IActionResult Index()
        {
            return View("List", model.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            Instructor instructor = model.GetOne(id);

            ViewBag.Previous = model.GetPreviousId();
            ViewBag.Next = model.GetNextId();

            return View(instructor);
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            ViewBag.DeptsIds = (from depts in dept.GetAll()
                               select new { depts.Id, depts.Name }).ToList();
            if (id == 0)
                return View(new Instructor());
            return View(model.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
            ViewBag.DeptsIds = (from dept in dept.GetAll()
                                select new { dept.Id, dept.Name }).ToList();
            return View("Add", instructor);
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
            return PartialView("List", model.GetRelativeToDepartment(deptId));
        }
    }
}
