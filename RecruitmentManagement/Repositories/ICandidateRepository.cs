using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> AddCandidate(CandidateDTO Candidate);
        Task<Candidate> UpdateCandidate(Candidate Candidate);
        Task<bool> DeleteCandidate(int id);

        Task<IEnumerable<Candidate>> BulkUpload(IFormFile file);

        Task<Candidate> GetCandidateFromUserId(int userId);
        Task<PositionCandidate> ApplyToPosition(int candidateId, int positionId);
    }
}