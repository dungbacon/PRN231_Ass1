using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.DTO;

namespace DataAccess.Repositories.Repo
{
    public class BookRepository : IBookRepository
    {

        private readonly IMapper mapper;

        public BookRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task DeleteBook(int id) => await BookDAO.Instance.DeleteBook(id);
        public async Task<BookDTO> GetBookByID(int id) => mapper.Map<BookDTO>(await BookDAO.Instance.GetBookByID(id));
        public async Task<List<BookDTO>> GetBooks() => mapper.Map<List<BookDTO>>(await BookDAO.Instance.GetBooks());
        public async Task<BookDTO> SaveBook(BookDTO p)
        {
            var book = mapper.Map<Book>(p);
            return mapper.Map<BookDTO>(await BookDAO.Instance.SaveBook(book));
        }
        public async Task<BookDTO> UpdateBook(BookDTO p)
        {
            var book = mapper.Map<Book>(p);
            return mapper.Map<BookDTO>(await BookDAO.Instance.UpdateBook(book));
        }
    }
}
