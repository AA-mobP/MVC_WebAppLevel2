using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;
using Mvc_WebApp_Level2.Models.BusinessLogic;

namespace MVC_WebAppLevel2.Controllers
{
    public class InstructorController : Controller
    {
        clsInstructor instructor = new();

        public IActionResult Index()
        {
            return View(instructor.GetAllInstructors());
        }
        
        public IActionResult Details(int id)
        {
            ViewBag.Previous = instructor.GetPrevious(id);
            ViewBag.Next = instructor.GetNext(id);

            return View(instructor.GetInstructor(id));
        }
    }
}
