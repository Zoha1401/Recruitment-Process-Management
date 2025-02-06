using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class RoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Role>> GetAllRoles() {
            return await _repository.GetAllRoles();
        } 
        public async Task<Role> GetRoleById(int id) {
            return await _repository.GetRoleById(id);
        }
        public async Task<Role> AddRole(Role role){
           return await _repository.AddRole(role);
        } 
        public async Task<Role> UpdateRole(Role role) {
            return await _repository.UpdateRole(role);
        } 
    
        public async Task<bool> DeleteRole(int id) {
            return await _repository.DeleteRole(id);
        } 
    }
}