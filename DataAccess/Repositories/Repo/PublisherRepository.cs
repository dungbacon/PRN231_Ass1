using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories.Repo
{
    public class PublisherRepository : IPublisherRepository
    {
        public async Task DeletePublisher(Publisher p) => await PublisherDAO.Instance.DeletePublisher(p);
        public async Task<Publisher> GetPublisherByID(int id) => await PublisherDAO.Instance.GetPublisherByID(id);
        public async Task<List<Publisher>> GetPublishers() => await PublisherDAO.Instance.GetPublishers();
        public async Task<List<Publisher>> GetPublishersByName(string s) => await PublisherDAO.Instance.GetPublishersByName(s);
        public async Task<List<Publisher>> GetPublishersByCity(string s) => await PublisherDAO.Instance.GetPublishersByCity(s);
        public async Task SavePublisher(Publisher p) => await PublisherDAO.Instance.SavePublisher(p);
        public async Task UpdatePublisher(Publisher p) => await PublisherDAO.Instance.UpdatePublisher(p);
    }
}
