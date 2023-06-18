using DataAccess.DTO;

namespace DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<BookDTO> SaveBook(BookDTO p);
        Task<BookDTO> GetBookByID(int id);
        Task DeleteBook(int id);
        Task<BookDTO> UpdateBook(BookDTO p);
        Task<List<BookDTO>> GetBooks();
    }
}
