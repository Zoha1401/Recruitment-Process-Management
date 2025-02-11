using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.DTOs;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IPositionCandidateRepository
    {
        Task<IEnumerable<PositionCandidate>> GetAllPositionCandidates();
        Task<PositionCandidate> GetPositionCandidateById(int id);
        Task<PositionCandidate> UpdatePositionCandidate(int positionCandidateId, PositionCandidateDTO PositionCandidate);
        Task<bool> DeletePositionCandidate(int id);

        Task<PositionCandidate> ReviewPositionCandidate(int position_PositionCandidate_id, bool isShortlisted, ICollection<MarkCandidateSkill> markPositionCandidateSkills);
        Task<PositionCandidate> ApplyToPosition (int userId, int candidateId, int positionId, int statusId);
        Task<IEnumerable<CandidateDTO>> ViewApplicants(int positionId);
        Task<IEnumerable<PositionRequest>> ViewApplications(int candidateId);
        Task<CandidateDTO> GetCandidateDetails(int positionCandidateId);
    }
}