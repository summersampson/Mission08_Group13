using Microsoft.EntityFrameworkCore;
using Mission08_Group13.Models;

namespace Mission08_Group13.Models;

// This class represents the database context and manages entity interactions with the database.
public class ApplicationDbContext : DbContext
{
    // Constructor: Passes database configuration options to the base DbContext class.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet representing the Tasks table in the database.
    public DbSet<Task> Tasks { get; set; } // Ensure this exists!

    // DbSet representing the Categories table in the database.
    public DbSet<Category> Categories { get; set; }

    // This method configures the model during the database creation process.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data for the Categories table to ensure default categories exist.
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "Work" },
            new Category { CategoryId = 3, CategoryName = "School" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
    }
}
