using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.DTO;

namespace DataAccess.Repositories.Repo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IMapper mapper;

        public AuthorRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task DeleteAuthor(int id) => await AuthorDAO.Instance.DeleteAuthor(id);
        public async Task<AuthorDTO> GetAuthorByID(int id) => mapper.Map<AuthorDTO>(await AuthorDAO.Instance.GetAuthorByID(id));
        public async Task<List<AuthorDTO>> GetAuthors() => mapper.Map<List<AuthorDTO>>(await AuthorDAO.Instance.GetAuthors());
        public async Task<List<AuthorDTO>> GetAuthorByFirstName(string s) => mapper.Map<List<AuthorDTO>>(await AuthorDAO.Instance.GetAuthorByFirstName(s));
        public async Task<List<AuthorDTO>> GetAuthorByLastName(string s) => mapper.Map<List<AuthorDTO>>(await AuthorDAO.Instance.GetAuthorByLastName(s));
        public async Task<List<AuthorDTO>> GetAuthorByCity(string s) => mapper.Map<List<AuthorDTO>>(await AuthorDAO.Instance.GetAuthorByCity(s));
        public async Task<AuthorDTO> SaveAuthor(AuthorDTO p)
        {
            var author = mapper.Map<Author>(p);
            return mapper.Map<AuthorDTO>(await AuthorDAO.Instance.SaveAuthor(author));
        }
        public async Task<AuthorDTO> UpdateAuthor(AuthorDTO p)
        {
            var author = mapper.Map<Author>(p);
            return mapper.Map<AuthorDTO>(await AuthorDAO.Instance.UpdateAuthor(author));
        }
    }
}
