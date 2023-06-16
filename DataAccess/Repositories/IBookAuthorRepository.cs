using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IBookAuthorRepository
    {
        void SaveBookAuthor(BookAuthor p);
        BookAuthor GetBookAuthorByAuthorID(int id);
        BookAuthor GetBookAuthorByBookID(int id);
        void DeleteBookAuthor(BookAuthor p);
        void UpdateBookAuthor(BookAuthor p);
        List<BookAuthor> GetBookAuthors();
    }
}
