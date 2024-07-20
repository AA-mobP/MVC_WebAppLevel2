using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace MVC_WebAppLevel2.Controllers
{
    public class InstructorController : Controller
    {
        IclsInstructor model;

        public InstructorController(IclsInstructor _model)
        {
            model = _model;
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

        public IActionResult Delete(int id)
        {
            model.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult RelativeInfo(int deptId)
        {
            return PartialView("List", model.GetRelativeToDepartment(deptId));
        }
    }
}
