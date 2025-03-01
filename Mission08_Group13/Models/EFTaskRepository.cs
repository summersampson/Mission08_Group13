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
        public List<Category> Categories => _context.Categories.ToList();

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


        public List<Task> GetTasks()
        {
            return _context.Tasks
                .Include(x => x.Category)
                .ToList();
        }

        public Task GetId(int id)
        {
            return _context.Tasks
                .Single(x => x.TaskId == id);
        }

        public void UpdateTask(Task updatedInfo)
        {
            _context.Tasks.Update(updatedInfo); // the post that updates the record with the updatedInfo passed
            _context.SaveChanges();
        }

        public void MarkTaskComplete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                task.IsComplete = true;
                _context.SaveChanges();
            }
        }

    }
}
