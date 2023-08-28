using smth.DbAccess;
using smth.Models;

namespace smth.BookData
{
    public class BookData : IBookData
    {
        private readonly IBookDbAccess _db;
        private string con= "Data Source=localhost;Initial Catalog=pages;Integrated Security=True;Trust Server Certificate=true";
        public BookData(IBookDbAccess db)
        {
            _db = db;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var info = await _db.LoadInfo<Book, dynamic>("Select * from dbo.AllBooks", new { }, con);
            return info;
        }
        public async Task<List<Book>> GetOneBook(int id)
        {
            var info = await _db.LoadInfo<Book, dynamic>("Select * from dbo.AllBooks where Id='" + id + "'", new { Id = id }, con);
            return info;
        }

        public async Task<List<Book>>GetByName(string name)
        {
            var info = await _db.LoadInfo<Book, dynamic>("Select * from dbo.AllBooks where Name='" + name + "'", new { Name = name }, con);
            return info;
        }
        public async Task<List<Book>> GetByAuthor(string author)
        {
            var info = await _db.LoadInfo<Book, dynamic>("Select * from dbo.AllBooks where Author='" + author + "'", new { Author = author }, con);
            return info;
        }

        public  Task SaveBookEdit(string name, string description, string author, string publisher, int year, string genra, int id, Book bok)
        {
            string sql = "Update dbo.AllBooks set Name='" + name + "', Description='" + description + "', Author='" + author + "', Publisher='" + publisher + "', Year='" + year + "', Genra='" + genra + "' where Id='" + id + "'";
            var info = _db.SaveInfo(sql,bok , con);
            Console.WriteLine(name + " " + description + " " + author + " " + publisher + " " + year.ToString() + " " + genra + " " + id.ToString()) ;
            return info;
        }

        public Task DeleteBook(int id) 
        {
            var info = _db.SaveInfo("Delete from dbo.AllBooks where Id='" + id + "'", new {Id=id}, con);
            return info;
        }

        public Task AddNewBook(Book bok) 
        {
            var info = _db.SaveInfo("Insert into dbo.AllBooks(Name,Description, Author, Publisher, Year, Genra) VALUES ('"+bok.Name+"','"+bok.Description+"','"+bok.Author+"','"+bok.Publisher+"','"+bok.Year+"','"+bok.Genra+"')", bok,con);
            return info;
        }

    }
}
