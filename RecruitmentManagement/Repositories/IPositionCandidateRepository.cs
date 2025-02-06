using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IPositionCandidateRepository
    {
        Task<IEnumerable<PositionCandidate>> GetAllPositionCandidates();
        Task<PositionCandidate> GetPositionCandidateById(int id);
        Task<PositionCandidate> UpdatePositionCandidate(PositionCandidate PositionCandidate);
        Task<bool> DeletePositionCandidate(int id);

        Task<PositionCandidate> ReviewPositionCandidate(int position_PositionCandidate_id, bool isShortlisted, ICollection<MarkCandidateSkill> markPositionCandidateSkills);
        Task<PositionCandidate> ApplyToPosition (int candidateId, int positionId);
        
    }
}