using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO
{
    public class RoleDAO
    {

        private static RoleDAO instance;

        private RoleDAO()
        {
        }

        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDAO();
                }
                return instance;
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            var list = new List<Role>();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    list = await context.Roles.ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<Role> GetRoleByID(int id)
        {
            var role = new Role();
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    role = await context.Roles.Where(s => s.RoleId == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return role;
        }

        public async Task SaveRole(Role role)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    await context.Roles.AddAsync(role);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateRole(Role role)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Entry<Role>(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteRole(Role role)
        {
            try
            {
                using (var context = new EBookStoreDbContext())
                {
                    context.Roles.Remove(role);
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
