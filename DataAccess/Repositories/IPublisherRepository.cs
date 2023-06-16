using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IPublisherRepository
    {
        Task SavePublisher(Publisher p);
        Task<Publisher> GetPublisherByID(int id);
        Task DeletePublisher(Publisher p);
        Task UpdatePublisher(Publisher p);
        Task<List<Publisher>> GetPublishers();
        Task<List<Publisher>> GetPublishersByName(string s);
        Task<List<Publisher>> GetPublishersByCity(string s);
    }
}
