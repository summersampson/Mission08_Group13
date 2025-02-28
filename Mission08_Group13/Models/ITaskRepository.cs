namespace Mission08_Group13.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        public void AddTask(Task t);
        public void RemoveTask(Task t);
        public void UpdateTask(Task t);

        public Task GetId(int id);
        public List<Task> GetTasks();
    }
}
