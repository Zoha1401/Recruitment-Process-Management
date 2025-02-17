using Microsoft.AspNetCore.SignalR.Protocol;
using RecruitmentManagement.DTOs;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class PositionCandidateService
    {
        private readonly IPositionCandidateRepository _repository;

        public PositionCandidateService(IPositionCandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PositionCandidate>> GetAllPositionCandidates() {
            return await _repository.GetAllPositionCandidates();
        } 
        public async Task<PositionCandidate> GetPositionCandidateById(int id) {
            return await _repository.GetPositionCandidateById(id);
        }
        // public async Task<PositionCandidate> AddPositionCandidate(PositionCandidate PositionCandidate){
        //    return await _repository.AddPositionCandidate(PositionCandidate);
        // } 
        public async Task<PositionCandidate> UpdatePositionCandidate(int positionCandidateId, PositionCandidateDTO PositionCandidate) {
            return await _repository.UpdatePositionCandidate(positionCandidateId, PositionCandidate);
        } 
    
        public async Task<bool> DeletePositionCandidate(int id) {
            return await _repository.DeletePositionCandidate(id);
        } 

        public async Task<PositionCandidate> ReviewPositionCandidate(int positionCandidateId, bool isShortlisted, ICollection<MarkCandidateSkill> MarkCandidateSkills){
            return await _repository.ReviewPositionCandidate(positionCandidateId, isShortlisted, MarkCandidateSkills);
        }

        public async Task<PositionCandidate> ApplyToPosition(int userId, int candidateId, int positionId, int statusId){
            return await _repository.ApplyToPosition(userId, candidateId, positionId, statusId);
        }

        public async Task<CandidateDTO> GetCandidateDetails(int positionCandidateId){
            return await _repository.GetCandidateDetails(positionCandidateId);
          }
        public async Task<IEnumerable<PositionRequest>> ViewApplications(int candidateId){
            return await _repository.ViewApplications(candidateId);
           }

        public async Task<IEnumerable<CandidateDTO>> ViewApplicants(int positionId){
            return await _repository.ViewApplicants(positionId);
        }
    }
}