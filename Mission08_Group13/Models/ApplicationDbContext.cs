using Microsoft.EntityFrameworkCore;
using Mission08_Group13.Models;
namespace Mission08_Group13.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; } // Ensure this exists!

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //seed data for the database if not already in there
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "Work" },
            new Category { CategoryId = 3, CategoryName = "School" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
}