using Microsoft.AspNetCore.Mvc;
using Mvc_WebApp_Level2.Models;

namespace MVC_WebAppLevel2.Controllers
{
    public class InstructorController : Controller
    {
        AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Instructor> model = _context.instructors.ToList();
            return View(model);
        }
        
        public IActionResult Details(int id)
        {
            Instructor? model = _context.instructors.FirstOrDefault(m => m.Id == id);
            return View(model);
        }
    }
}
