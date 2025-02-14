using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class CandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates() {
            return await _repository.GetAllCandidates();
        } 
        public async Task<Candidate> GetCandidateById(int id) {
            return await _repository.GetCandidateById(id);
        }
        public async Task<Candidate> AddCandidate(CandidateDTO Candidate){
           return await _repository.AddCandidate(Candidate);
        } 
        public async Task<Candidate> UpdateCandidate(Candidate Candidate) {
            return await _repository.UpdateCandidate(Candidate);
        } 
    
        public async Task<bool> DeleteCandidate(int id) {
            return await _repository.DeleteCandidate(id);
        } 

        public async Task<IEnumerable<Candidate>> BulkUpload(IFormFile file){
           return await _repository.BulkUpload(file);
        }

         public async Task<Candidate> GetCandidateFromUserId(int userId){
            return await _repository.GetCandidateFromUserId(userId);
         }
        public async Task<PositionCandidate> ApplyToPosition(int candidateId, int positionId){
            return await _repository.ApplyToPosition(candidateId, positionId);
        }
    }
}