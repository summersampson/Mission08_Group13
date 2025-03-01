using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Group13.Models;

namespace Mission08_Group13.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        // Constructor: Injects the repository dependency
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        // Home page: Displays all tasks
        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }

        // Quadrants view: Displays only incomplete tasks in their respective quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.IsComplete) // Only show tasks that are not completed
                .ToList();

            ViewBag.Categories = _repo.Categories.ToList(); // Load categories for filtering or display
            return View(tasks);
        }

        // Loads the Add/Edit Task page
        public IActionResult AddEditTask(int? id)
        {
            ViewBag.Categories = _repo.Categories.ToList(); // Load categories for dropdown
            ViewBag.Tasks = _repo.GetTasks(); // Load all tasks

            if (id == null || id == 0)
            {
                // If no ID is provided, return a blank task form (adding a new task)
                return View(new Models.Task());
            }
            else
            {
                // If an ID is provided, fetch the task for editing
                var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
                if (task == null)
                {
                    return NotFound(); // Return a 404 error if the task is not found
                }
                return View(task);
            }
        }

        // Saves a new or edited task to the database
        [HttpPost]
        public IActionResult SaveTask(Models.Task task)
        {
            if (ModelState.IsValid) // Check if the model passes validation
            {
                if (task.TaskId == 0) // If TaskId is 0, it's a new task
                {
                    _repo.AddTask(task); // Add new task using repository
                }
                else // If TaskId exists, it's an edit operation
                {
                    _repo.UpdateTask(task); // Update the existing task using repository
                }
                return RedirectToAction("AddEditTask"); // Redirect back to Add/Edit page
            }

            // If validation fails, reload the form with existing data
            ViewBag.Categories = _repo.Categories.ToList();
            return View("AddEditTask", task);
        }

        // Loads the Edit Task view
        public IActionResult EditTask(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound(); // Return a 404 error if the task is not found
            }

            ViewBag.Categories = _repo.Categories.ToList(); // Load categories for dropdown
            return View("AddEditTask", task); // Reuse the same view as AddTask
        }

        // Loads the Add Task view
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.ToList(); // Load categories for dropdown
            return View("AddEditTask", new Models.Task()); // Return an empty task form
        }

        // Loads the Delete Task confirmation page
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var recordToDelete = _repo.GetId(id); // Fetch the task by ID

            return View(recordToDelete); // Return the view with the task to confirm deletion
        }

        // Handles the deletion of a task
        [HttpPost]
        public IActionResult DeleteTask(Models.Task recordToDelete)
        {
            _repo.RemoveTask(recordToDelete); // Remove the task using repository

            return RedirectToAction("AddEditTask"); // Redirect back to task list
        }

        // Marks a task as complete when the checkbox is checked
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.GetId(id); // Fetch task using repository method
            if (task != null)
            {
                task.IsComplete = true; // Mark the task as complete
                _repo.UpdateTask(task); // Save changes to the database
                return Ok(); // Return a success response
            }
            return NotFound(); // Return a 404 if the task is not found
        }
    }
}
