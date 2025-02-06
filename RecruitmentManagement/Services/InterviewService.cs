using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class InterviewService
    {
        private readonly IInterviewRepository _repository;

        public InterviewService(IInterviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Interview>> GetAllInterviews() {
            return await _repository.GetAllInterviews();
        } 
        public async Task<Interview> GetInterviewById(int id) {
            return await _repository.GetInterviewById(id);
        }
        public async Task<Interview> AddInterview(Interview Interview){
           return await _repository.AddInterview(Interview);
        } 
        public async Task<Interview> UpdateInterview(Interview Interview) {
            return await _repository.UpdateInterview(Interview);
        } 
    
        public async Task<bool> DeleteInterview(int id) {
            return await _repository.DeleteInterview(id);
        } 
    }
}