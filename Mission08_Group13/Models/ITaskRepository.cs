namespace Mission08_Group13.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task t);
    }
}
