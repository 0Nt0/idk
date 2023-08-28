using System.ComponentModel.DataAnnotations;

namespace smth.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string Genra { get; set; }
    }
}