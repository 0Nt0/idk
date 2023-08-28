using _2uzd.Data;
using _2uzd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2uzd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookDbContext _context;
        public BookController(BookDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("Title")]
        public async Task<IActionResult> GetByTitleAsync(string Title)
        {
            var book = await _context.Books.Where(x => x.Title == Title).ToListAsync();
            return book == null ? NotFound() : Ok(book);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(AddBook), new { Id = book.Id }, book);
        }
        [HttpPut("PutById/{Id}")]
        public async Task<IActionResult> UpdateBook(int Id, Book book)
        {
            if(Id !=book.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return book == null ? NotFound() : Ok(book);
            }
        }
        
        [HttpPut("PutByTitle/{Title}")]
        public async Task<IActionResult> UpdateBookOnTitle(string Title, Book book)
        {
            var update = await _context.Books.Where(x => x.Title == Title).ToListAsync();
            if (update==null)
            {
                return NotFound();
            }
            else
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return book == null ? NotFound() : Ok(book);
            }
        }
        
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBook(int Id, Book book)
        {
            var delete = await _context.Books.FindAsync(Id);
            if(delete==null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(delete);
                await _context.SaveChangesAsync();
                return Ok("The book was deleted");
            }
        }
        [HttpGet]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            return Ok(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }

    }
}
