using System.ComponentModel.DataAnnotations;

namespace Mission08_Group13.Models;

public class TaskModel
{
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string TaskName { get; set; }

    [Required]
    public int Quadrant { get; set; } // 1-4 Quadrants

    public DateTime? DueDate { get; set; }

    [Required]
    public string Category { get; set; } // Updated to match teammate's format

    public bool IsComplete { get; set; } = false;
}