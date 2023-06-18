using DataAccess.DTO;

namespace DataAccess.Repositories
{
    public interface IPublisherRepository
    {
        Task<PublisherDTO> SavePublisher(PublisherDTO p);
        Task<PublisherDTO> GetPublisherByID(int id);
        Task DeletePublisher(int id);
        Task<PublisherDTO> UpdatePublisher(PublisherDTO p);
        Task<List<PublisherDTO>> GetPublishers();
        Task<List<PublisherDTO>> GetPublishersByName(string s);
        Task<List<PublisherDTO>> GetPublishersByCity(string s);
    }
}
