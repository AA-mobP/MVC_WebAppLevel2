using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;

namespace Mvc_WebApp_Level2.Controllers
{
    public class DepartmentController : Controller
    {
        private clsDepartment model = new();

        public IActionResult Index()
        {
            //List of Departments
            return View("List", model.GetAll());
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
            if (ModelState.IsValid)
            {
                if (department.Id == 0)
                    model.Add(department);
                else
                    model.Edit(department);
                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            model.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
