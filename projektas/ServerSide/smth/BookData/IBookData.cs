using smth.Models;

namespace smth.BookData
{
    public interface IBookData
    {
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetOneBook(int id);
        Task<List<Book>> GetByName(string name);
        Task<List<Book>> GetByAuthor(string author);
        Task SaveBookEdit(string name, string description, string author, string publisher, int year, string genra, int id, Book bok);
        Task DeleteBook(int id);
        Task AddNewBook(Book bok);
    }
}