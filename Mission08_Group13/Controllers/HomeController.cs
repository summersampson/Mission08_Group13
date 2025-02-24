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
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
