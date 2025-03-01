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

        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.IsComplete) // Only show incomplete tasks
                .ToList();

            ViewBag.Categories = _repo.Categories.ToList(); // Ensure categories are available
            return View(tasks);
        }

        public IActionResult AddEditTask(int? id)
        {
            ViewBag.Categories = _repo.Categories.ToList();
            ViewBag.Tasks = _repo.GetTasks();

            if (id == null || id == 0)
            {
                // New Task
                return View(new Models.Task());
            }
            else
            {
                // Edit Existing Task
                var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult SaveTask(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0) // New Task
                {
                    _repo.AddTask(task); // Use repository method
                }
                else // Existing Task (Edit)
                {
                    _repo.UpdateTask(task); // Use repository method
                }
                return RedirectToAction("AddEditTask");
            }

            // If validation fails, reload the form with existing data
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEditTask", task);
        }

        public IActionResult EditTask(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEditTask", task);
        }

        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEditTask", new Models.Task());
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var recordToDelete = _repo.GetId(id); // get the record to delete

            return View(recordToDelete); // return the view with the record to delete
        }

        [HttpPost]
        public IActionResult DeleteTask(Models.Task recordToDelete)
        {
            _repo.RemoveTask(recordToDelete); // remove the record

            return RedirectToAction("AddEditTask"); // return to the MovieList
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.GetId(id); // Use repository method to get task
            if (task != null)
            {
                task.IsComplete = true;
                _repo.UpdateTask(task); // Use repository method to update task
                return Ok();
            }
            return NotFound();
        }



    }
}

