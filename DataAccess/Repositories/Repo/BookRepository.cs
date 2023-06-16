using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories.Repo
{
    public class BookRepository : IBookRepository
    {
        public async Task DeleteBook(Book p) => await BookDAO.Instance.DeleteBook(p);
        public async Task<Book> GetBookByID(int id) => await BookDAO.Instance.GetBookByID(id);
        public async Task<List<Book>> GetBooks() => await BookDAO.Instance.GetBooks();
        public async Task SaveBook(Book p) => await BookDAO.Instance.SaveBook(p);
        public async Task UpdateBook(Book p) => await BookDAO.Instance.UpdateBook(p);
    }
}
