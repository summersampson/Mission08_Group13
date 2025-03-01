using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Group13.Models;

// create a class for the Tasks
// make the Task table with the columns and data types
public class Task
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string? TaskName { get; set; }

    [Required]
    public int Quadrant { get; set; } // 1-4 Quadrants

    public DateTime? DueDate { get; set; }

    //sets up foreign key relationship
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool IsComplete { get; set; } = false;
}