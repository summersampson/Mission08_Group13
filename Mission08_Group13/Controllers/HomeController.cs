using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Group13.Models;

namespace Mission08_Group13.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }


        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }

        //not sure if i need to change this to ViewBag.Tasks instead?
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.IsComplete) // Only show incomplete tasks
                .ToList();

            return View(tasks);
        }

        public IActionResult AddEditTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

    }
}
