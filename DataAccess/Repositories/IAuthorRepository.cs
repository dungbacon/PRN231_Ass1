using DataAccess.DTO;

namespace DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        Task<AuthorDTO> SaveAuthor(AuthorDTO p);
        Task<AuthorDTO> GetAuthorByID(int id);
        Task DeleteAuthor(int id);
        Task<AuthorDTO> UpdateAuthor(AuthorDTO p);
        Task<List<AuthorDTO>> GetAuthors();
        Task<List<AuthorDTO>> GetAuthorByFirstName(string s);
        Task<List<AuthorDTO>> GetAuthorByLastName(string s);
        Task<List<AuthorDTO>> GetAuthorByCity(string s);
    }
}
