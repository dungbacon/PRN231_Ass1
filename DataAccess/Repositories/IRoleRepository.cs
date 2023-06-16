using BusinessObject.Models;

namespace DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task SaveRole(Role p);
        Task<Role> GetRoleByID(int id);
        Task DeleteRole(Role p);
        Task UpdateRole(Role p);
        Task<List<Role>> GetRoles();
    }
}
