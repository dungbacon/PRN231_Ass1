using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        Task SaveAuthor(Author p);
        Task<Author> GetAuthorByID(int id);
        Task DeleteAuthor(Author p);
        Task UpdateAuthor(Author p);
        Task<List<Author>> GetAuthors();
        Task<List<Author>> GetAuthorByFirstName(string s);
        Task<List<Author>> GetAuthorByLastName(string s);
        Task<List<Author>> GetAuthorByCity(string s);
    }
}
