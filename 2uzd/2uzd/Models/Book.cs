using System.ComponentModel.DataAnnotations;

namespace _2uzd.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        public string BookType { get; set; }

    }
    
}
