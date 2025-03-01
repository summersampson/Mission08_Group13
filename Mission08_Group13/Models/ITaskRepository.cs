namespace Mission08_Group13.Models
{
    // Interface defining the contract for a task repository.
    // This ensures that any class implementing ITaskRepository follows a consistent structure.
    public interface ITaskRepository
    {
        // Property to retrieve a list of all tasks from the database.
        List<Task> Tasks { get; }

        // Property to retrieve a list of all categories from the database.
        List<Category> Categories { get; }

        // Method to add a new task to the repository.
        void AddTask(Task t);

        // Method to remove a task from the repository.
        void RemoveTask(Task t);

        // Method to update an existing task in the repository.
        void UpdateTask(Task t);

        // Method to retrieve a specific task by its ID.
        Task GetId(int id);

        // Method to retrieve all tasks including their associated categories.
        List<Task> GetTasks();

        // Method to mark a task as complete by updating its IsComplete property.
        void MarkTaskComplete(int id);
    }
}
