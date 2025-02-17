using Microsoft.EntityFrameworkCore;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RecruitmentDbContext _context;

        public RoleRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> AddRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}