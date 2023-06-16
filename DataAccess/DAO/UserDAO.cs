using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class UserDAO
    {

        private static UserDAO instance;

        private UserDAO()
        {
        }

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var list = new List<User>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Users.ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<User> AuthenticateUser(string email, string pwd)
        {
            var user = new User();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    user = await context.Users.Where(s => s.EmailAddress == email && s.Password == pwd).Include(s => s.Role).Include(s => s.Publisher)
                        .FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = new User();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    user = await context.Users.Where(s => s.EmailAddress == email).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public async Task<User> GetUserByID(int id)
        {
            var user = new User();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    user = await context.Users.Where(s => s.UserId == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public async Task SaveUser(User user)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Users.AddAsync(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<User>(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Users.Remove(user);
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
