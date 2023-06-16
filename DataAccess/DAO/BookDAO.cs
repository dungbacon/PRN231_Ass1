using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class BookDAO
    {

        private static BookDAO instance;

        private BookDAO()
        {
        }

        public static BookDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookDAO();
                }
                return instance;
            }
        }

        public async Task<List<Book>> GetBooks()
        {
            var list = new List<Book>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Books.ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<Book> GetBookByID(int id)
        {
            var book = new Book();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    book = await context.Books.Where(s => s.BookId == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return book;
        }

        public async Task SaveBook(Book book)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Books.AddAsync(book);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateBook(Book book)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<Book>(book).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteBook(Book book)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
