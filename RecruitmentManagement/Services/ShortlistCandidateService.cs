using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class ShortlistCandidateService
    {
        private readonly IShortlistCandidateRepository _repository;

        public ShortlistCandidateService(IShortlistCandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ShortlistCandidate>> GetAllShortlistCandidates() {
            return await _repository.GetAllShortlistCandidates();
        } 
        public async Task<ShortlistCandidate> GetShortlistCandidateById(int id) {
            return await _repository.GetShortlistCandidateById(id);
        }
        public async Task<ShortlistCandidate> AddShortlistCandidate(ShortlistCandidateDTO ShortlistCandidate){
           return await _repository.AddShortlistCandidate(ShortlistCandidate);
        } 
        public async Task<ShortlistCandidate> UpdateShortlistCandidate(int shortlist_candidate_id, ShortlistCandidateDTO ShortlistCandidate) {
            return await _repository.UpdateShortlistCandidate(shortlist_candidate_id, ShortlistCandidate);
        } 
    
        public async Task<bool> DeleteShortlistCandidate(int id) {
            return await _repository.DeleteShortlistCandidate(id);
        } 
    }
}