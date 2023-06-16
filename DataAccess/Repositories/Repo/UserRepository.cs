using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories.Repo
{
    public class UserRepository : IUserRepository
    {
        public async Task DeleteUser(User p) => await UserDAO.Instance.DeleteUser(p);
        public async Task<User> GetUserByID(int id) => await UserDAO.Instance.GetUserByID(id);
        public async Task<User> AuthenticateUser(string email, string pwd) => await UserDAO.Instance.AuthenticateUser(email, pwd);
        public async Task<User> GetUserByEmail(string email) => await UserDAO.Instance.GetUserByEmail(email);
        public async Task<List<User>> GetUsers() => await UserDAO.Instance.GetUsers();
        public async Task SaveUser(User p) => await UserDAO.Instance.SaveUser(p);
        public async Task UpdateUser(User p) => await UserDAO.Instance.UpdateUser(p);
    }
}
