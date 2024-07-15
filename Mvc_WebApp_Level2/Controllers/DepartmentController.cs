using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;

namespace Mvc_WebApp_Level2.Controllers
{
    public class DepartmentController : Controller
    {
        private static clsDepartment model = new();

        public IActionResult Index()
        {
            //List of Departments
            model = new();
            return View(model.GetAll());
        }

        public IActionResult Details(int id)
        {
            Department department = model.GetOne(id);
            
            ViewBag.Previous = model.GetPreviousId();
            ViewBag.Next = model.GetNextId();

            return View(department);
        }

        public IActionResult Add(int id)
        {
            if (id == 0)
                return View(new Department());
            return View(model.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Department department)
        {
            if (department.Id == 0)
                model.Add(department);
            else
                model.Edit(department);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
