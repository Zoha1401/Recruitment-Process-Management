using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class SkillService
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills() {
            return await _repository.GetAllSkills();
        } 
        public async Task<Skill> GetSkillById(int id) {
            return await _repository.GetSkillById(id);
        }
        public async Task<Skill> AddSkill(Skill Skill){
           return await _repository.AddSkill(Skill);
        } 
        public async Task<Skill> UpdateSkill(Skill Skill) {
            return await _repository.UpdateSkill(Skill);
        } 
    
        public async Task<bool> DeleteSkill(int id) {
            return await _repository.DeleteSkill(id);
        } 
    }
}