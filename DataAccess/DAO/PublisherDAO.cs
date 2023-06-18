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

        public async Task<Publisher> SavePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Publishers.AddAsync(publisher);
                    context.SaveChanges();
                    return await context.Publishers.Where(s => s.PubId == publisher.PubId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Publisher> UpdatePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<Publisher>(publisher).State = EntityState.Modified;
                    context.SaveChanges();
                    return await context.Publishers.Where(s => s.PubId == publisher.PubId).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePublisher(int id)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    var publisher = await context.Publishers.Where(s => s.PubId == id).FirstOrDefaultAsync();
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
