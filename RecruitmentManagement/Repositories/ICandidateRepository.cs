using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> AddCandidate(Candidate Candidate);
        Task<Candidate> UpdateCandidate(Candidate Candidate);
        Task<bool> DeleteCandidate(int id);
        
    }
}