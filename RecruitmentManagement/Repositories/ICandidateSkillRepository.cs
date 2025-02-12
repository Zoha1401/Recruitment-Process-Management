using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface ICandidateSkillRepository
    {
        Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills();
        Task<CandidateSkill> GetCandidateSkillById(int id);
        Task<CandidateSkill> AddCandidateSkill(int candidateId, int skillId, MarkCandidateSkill CandidateSkill);
        Task<CandidateSkill> UpdateCandidateSkill(int candidateId, int skillId, MarkCandidateSkill CandidateSkill);
        Task<bool> DeleteCandidateSkill(int id);
        
        Task<List<CandidateSkillDTO>> GetCandidateSkills(int id);
    }
}