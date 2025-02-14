using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IShortlistCandidateRepository
    {
        Task<IEnumerable<ShortlistCandidate>> GetAllShortlistCandidates();
        Task<ShortlistCandidate> GetShortlistCandidateById(int id);
        Task<ShortlistCandidate> AddShortlistCandidate(ShortlistCandidateDTO ShortlistCandidate);
        Task<ShortlistCandidate> UpdateShortlistCandidate(int shortlist_candidate_id, ShortlistCandidateDTO ShortlistCandidate);
        Task<bool> DeleteShortlistCandidate(int id);

        Task<IEnumerable<ShortlistedCandidateDTO>> GetAllShortlistedCandidates();

        Task<bool> IsShortlisted(int candidateId);
        
    }
}