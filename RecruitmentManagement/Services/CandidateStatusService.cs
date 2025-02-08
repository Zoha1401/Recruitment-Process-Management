using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class CandidateStatusService
    {
        private readonly ICandidateStatusRepository _repository;

        public CandidateStatusService(ICandidateStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuss() {
            return await _repository.GetAllCandidateStatuss();
        } 
        public async Task<CandidateStatus> GetCandidateStatusById(int id) {
            return await _repository.GetCandidateStatusById(id);
        }
        public async Task<CandidateStatus> AddCandidateStatus(CandidateStatus CandidateStatus){
           return await _repository.AddCandidateStatus(CandidateStatus);
        } 
        public async Task<CandidateStatus> UpdateCandidateStatus(CandidateStatus CandidateStatus) {
            return await _repository.UpdateCandidateStatus(CandidateStatus);
        } 
    
        public async Task<bool> DeleteCandidateStatus(int id) {
            return await _repository.DeleteCandidateStatus(id);
        } 
    }
}