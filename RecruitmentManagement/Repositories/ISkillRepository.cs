using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int id);
        Task<Skill> AddSkill(Skill Skill);
        Task<Skill> UpdateSkill(Skill Skill);
        Task<bool> DeleteSkill(int id);
        
    }
}