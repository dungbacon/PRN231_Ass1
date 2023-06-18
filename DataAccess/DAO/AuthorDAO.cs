using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        private static AuthorDAO instance;

        private AuthorDAO()
        {
        }

        public static AuthorDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthorDAO();
                }
                return instance;
            }
        }

        public async Task<List<Author>> GetAuthors()
        {
            var list = new List<Author>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Authors.Include(s => s.BookAuthors).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<Author> GetAuthorByID(int id)
        {
            var author = new Author();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    author = await context.Authors.Where(s => s.AuthorId == id).Include(s => s.BookAuthors).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return author;
        }

        public async Task<List<Author>> GetAuthorByFirstName(string fname)
        {
            var authors = new List<Author>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    authors = await context.Authors.Where(s => s.FirstName == fname).Include(s => s.BookAuthors).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return authors;
        }

        public async Task<List<Author>> GetAuthorByLastName(string lname)
        {
            var authors = new List<Author>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    authors = await context.Authors.Where(s => s.LastName == lname).Include(s => s.BookAuthors).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return authors;
        }

        public async Task<List<Author>> GetAuthorByCity(string city)
        {
            var authors = new List<Author>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    authors = await context.Authors.Where(s => s.City == city).Include(s => s.BookAuthors).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return authors;
        }

        public async Task<Author> SaveAuthor(Author author)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Authors.AddAsync(author);
                    context.SaveChanges();
                    return await context.Authors.FirstOrDefaultAsync(x => x.AuthorId == author.AuthorId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry(author).State = EntityState.Modified;
                    context.SaveChanges();
                    return await context.Authors.FirstOrDefaultAsync(x => x.AuthorId == author.AuthorId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteAuthor(int id)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    var item = await context.Authors.Where(s => s.AuthorId == id).FirstOrDefaultAsync();
                    context.Authors.Remove(item);
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
