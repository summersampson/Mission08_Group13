namespace Mission08_Group13.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private ApplicationDbContext _context;
        public EFTaskRepository(ApplicationDbContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();

        public void AddTask(Task t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void RemoveTask(Task t) 
        {
            _context.Tasks.Remove(t);
            _context.SaveChanges();
        }

        public void GetTasks() 
        {
            _context.Tasks
                .Include(x => x.Category)
                .ToList();
        }

    }
}
