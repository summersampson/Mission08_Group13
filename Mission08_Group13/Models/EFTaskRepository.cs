using Microsoft.EntityFrameworkCore;

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

        public void GetId(int id)
        {
            _context.Tasks
                .Single(x => x.TaskId == id);
        }

        public void UpdateTask(Task updatedInfo)
        {
            _context.Tasks.Update(updatedInfo); // the post that updates the record with the updatedInfo passed
            _context.SaveChanges();
        }

    }
}
