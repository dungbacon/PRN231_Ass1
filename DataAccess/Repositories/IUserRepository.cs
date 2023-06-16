using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task SaveUser(User p);
        Task<User> GetUserByID(int id);
        Task DeleteUser(User p);
        Task UpdateUser(User p);
        Task<List<User>> GetUsers();
        Task<User> AuthenticateUser(string email, string pwd);
        Task<User> GetUserByEmail(string email);
    }
}
