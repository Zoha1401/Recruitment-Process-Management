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
        Task<CandidateStatus> UpdateCandidateStatus(int id, CandidateStatusDTO CandidateStatus);
        Task<bool> DeleteCandidateStatus(int id);

        Task<IEnumerable<CandidateStatusType>> GetCandidateStatusTypes();

        Task<CandidateStatus> GetCandidateStatusFromIds(int candidateId, int positionId);
        
    }
}