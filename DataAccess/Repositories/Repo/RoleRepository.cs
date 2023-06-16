using BusinessObject.Models;
using DataAccess.DAO;

namespace DataAccess.Repositories.Repo
{
    public class RoleRepository : IRoleRepository
    {
        public async Task DeleteRole(Role p) => await RoleDAO.Instance.DeleteRole(p);
        public async Task<Role> GetRoleByID(int id) => await RoleDAO.Instance.GetRoleByID(id);
        public async Task<List<Role>> GetRoles() => await RoleDAO.Instance.GetRoles();
        public async Task SaveRole(Role p) => await RoleDAO.Instance.SaveRole(p);
        public async Task UpdateRole(Role p) => await RoleDAO.Instance.UpdateRole(p);
    }
}
