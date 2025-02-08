using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface ICandidateStatusRepository
    {
        Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuss();
        Task<CandidateStatus> GetCandidateStatusById(int id);
        Task<CandidateStatus> AddCandidateStatus(CandidateStatus CandidateStatus);
        Task<CandidateStatus> UpdateCandidateStatus(CandidateStatus CandidateStatus);
        Task<bool> DeleteCandidateStatus(int id);
        
    }
}