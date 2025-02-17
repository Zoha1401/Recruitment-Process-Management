using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<Role> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<bool> DeleteRole(int id);
        
    }
}