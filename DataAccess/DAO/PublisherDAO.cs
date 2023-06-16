using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {

        private static PublisherDAO instance;

        private PublisherDAO()
        {
        }

        public static PublisherDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PublisherDAO();
                }
                return instance;
            }
        }
        public async Task<List<Publisher>> GetPublishers()
        {
            var list = new List<Publisher>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Publishers.ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<List<Publisher>> GetPublishersByName(string name)
        {
            var list = new List<Publisher>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Publishers.Where(s => s.PubName == name).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<List<Publisher>> GetPublishersByCity(string city)
        {
            var list = new List<Publisher>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Publishers.Where(s => s.City == city).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<Publisher> GetPublisherByID(int id)
        {
            var publisher = new Publisher();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    publisher = await context.Publishers.Where(s => s.PubId == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisher;
        }

        public async Task SavePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Publishers.AddAsync(publisher);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdatePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<Publisher>(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Publishers.Remove(publisher);
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
