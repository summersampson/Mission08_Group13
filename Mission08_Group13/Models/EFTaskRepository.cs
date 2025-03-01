using Microsoft.EntityFrameworkCore;

namespace Mission08_Group13.Models
{
    // This class implements the ITaskRepository interface and interacts with the database using Entity Framework Core.
    public class EFTaskRepository : ITaskRepository
    {
        private ApplicationDbContext _context; // Database context for accessing the database.

        // Constructor: Initializes the repository with the provided database context.
        public EFTaskRepository(ApplicationDbContext temp)
        {
            _context = temp;
        }

        // Retrieves all tasks as a list from the database.
        public List<Task> Tasks => _context.Tasks.ToList();

        // Retrieves all categories as a list from the database.
        public List<Category> Categories => _context.Categories.ToList();

        // Adds a new task to the database and saves the changes.
        public void AddTask(Task t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        // Removes a task from the database and saves the changes.
        public void RemoveTask(Task t)
        {
            _context.Tasks.Remove(t);
            _context.SaveChanges();
        }

        // Retrieves all tasks from the database, including their related Category information.
        public List<Task> GetTasks()
        {
            return _context.Tasks
                .Include(x => x.Category) // Eager loading to include Category data
                .ToList();
        }

        // Retrieves a single task by its ID.
        public Task GetId(int id)
        {
            return _context.Tasks
                .Single(x => x.TaskId == id); // Finds the task with the matching ID
        }

        // Updates an existing task with new information and saves the changes.
        public void UpdateTask(Task updatedInfo)
        {
            _context.Tasks.Update(updatedInfo); // Marks the entity as modified
            _context.SaveChanges();
        }

        // Marks a task as complete by setting its IsComplete property to true and saves the changes.
        public void MarkTaskComplete(int id)
        {
            var task = _context.Tasks.Find(id); // Finds the task by its ID
            if (task != null) // If the task is found
            {
                task.IsComplete = true; // Set the task as complete
                _context.SaveChanges(); // Save the changes to the database
            }
        }
    }
}
