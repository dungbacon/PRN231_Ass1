using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories.Repo
{
    public class AuthorRepository : IAuthorRepository
    {
        public async Task DeleteAuthor(Author p) => await AuthorDAO.Instance.DeleteAuthor(p);
        public async Task<Author> GetAuthorByID(int id) => await AuthorDAO.Instance.GetAuthorByID(id);
        public async Task<List<Author>> GetAuthors() => await AuthorDAO.Instance.GetAuthors();
        public async Task<List<Author>> GetAuthorByFirstName(string s) => await AuthorDAO.Instance.GetAuthorByFirstName(s);
        public async Task<List<Author>> GetAuthorByLastName(string s) => await AuthorDAO.Instance.GetAuthorByLastName(s);
        public async Task<List<Author>> GetAuthorByCity(string s) => await AuthorDAO.Instance.GetAuthorByCity(s);
        public async Task SaveAuthor(Author p) => await AuthorDAO.Instance.SaveAuthor(p);
        public async Task UpdateAuthor(Author p) => await AuthorDAO.Instance.UpdateAuthor(p);
    }
}
