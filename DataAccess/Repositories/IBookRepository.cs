using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task SaveBook(Book p);
        Task<Book> GetBookByID(int id);
        Task DeleteBook(Book p);
        Task UpdateBook(Book p);
        Task<List<Book>> GetBooks();
    }
}
