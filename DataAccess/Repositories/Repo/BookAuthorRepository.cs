using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Repo
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        public void DeleteBookAuthor(BookAuthor p) => BookAuthorDAO.Instance.DeleteBookAuthor(p);


        public BookAuthor GetBookAuthorByAuthorID(int id) => BookAuthorDAO.Instance.GetBookAuthorByAuthorID(id);


        public BookAuthor GetBookAuthorByBookID(int id) => BookAuthorDAO.Instance.GetBookAuthorByBookID(id);


        public List<BookAuthor> GetBookAuthors() => BookAuthorDAO.Instance.GetBookAuthors();


        public void SaveBookAuthor(BookAuthor p) => BookAuthorDAO.Instance.SaveBookAuthor(p);


        public void UpdateBookAuthor(BookAuthor p) => BookAuthorDAO.Instance.UpdateBookAuthor(p);

    }
}
