using _2uzd.Models;
using Microsoft.EntityFrameworkCore;

namespace _2uzd.Data
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Book> Books { get; set; }

    }
}
