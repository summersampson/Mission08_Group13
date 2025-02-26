using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Group13.Models;

namespace Mission08_Group13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View("Quadrants");
        }

        //not sure if i need to change this to ViewBag.Tasks instead?
        public IActionResult Quadrants()
        {
            var tasks = _context.Tasks
                .Where(t => !t.IsComplete) // Only show incomplete tasks
                .ToList();

            return View(tasks);
        }

    }
}
