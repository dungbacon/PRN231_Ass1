using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookAuthorDAO
    {

        private static BookAuthorDAO instance;

        private BookAuthorDAO()
        {
        }

        public static BookAuthorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookAuthorDAO();
                }
                return instance;
            }
        }

        public List<BookAuthor> GetBookAuthors()
        {
            var list = new List<BookAuthor>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = context.BookAuthors.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public BookAuthor GetBookAuthorByAuthorID(int id)
        {
            var bookAuthor = new BookAuthor();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    bookAuthor = context.BookAuthors.Where(s => s.AuthorId == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bookAuthor;
        }

        public BookAuthor GetBookAuthorByBookID(int id)
        {
            var bookAuthor = new BookAuthor();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    bookAuthor = context.BookAuthors.Where(s => s.BookId == id).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bookAuthor;
        }

        public void SaveBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.BookAuthors.Add(bookAuthor);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<BookAuthor>(bookAuthor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.BookAuthors.Remove(bookAuthor);
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
