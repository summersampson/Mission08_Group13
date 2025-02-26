using System.ComponentModel.DataAnnotations;

namespace Mission08_Group13.Models
{
    // create a class for the category
    // make the Category table with the columns and data types
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
