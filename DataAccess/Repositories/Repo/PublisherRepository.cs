using AutoMapper;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.DTO;

namespace DataAccess.Repositories.Repo
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IMapper mapper;

        public PublisherRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task DeletePublisher(int id) => await PublisherDAO.Instance.DeletePublisher(id);
        public async Task<PublisherDTO> GetPublisherByID(int id) => mapper.Map<PublisherDTO>(await PublisherDAO.Instance.GetPublisherByID(id));
        public async Task<List<PublisherDTO>> GetPublishers() => mapper.Map<List<PublisherDTO>>(await PublisherDAO.Instance.GetPublishers());
        public async Task<List<PublisherDTO>> GetPublishersByName(string s) => mapper.Map<List<PublisherDTO>>(await PublisherDAO.Instance.GetPublishersByName(s));
        public async Task<List<PublisherDTO>> GetPublishersByCity(string s) => mapper.Map<List<PublisherDTO>>(await PublisherDAO.Instance.GetPublishersByCity(s));
        public async Task<PublisherDTO> SavePublisher(PublisherDTO p)
        {
            var item = mapper.Map<Publisher>(p);
            return mapper.Map<PublisherDTO>(await PublisherDAO.Instance.SavePublisher(item));
        }
        public async Task<PublisherDTO> UpdatePublisher(PublisherDTO p)
        {
            var item = mapper.Map<Publisher>(p);
            return mapper.Map<PublisherDTO>(await PublisherDAO.Instance.UpdatePublisher(item));
        }
    }
}
