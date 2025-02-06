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
        public async Task<Interview> AddInterview(InterviewRequest Interview){
           return await _repository.AddInterview(Interview);
        } 
        public async Task<Interview> UpdateInterview(Interview Interview) {
            return await _repository.UpdateInterview(Interview);
        } 
    
        public async Task<bool> DeleteInterview(int id) {
            return await _repository.DeleteInterview(id);
        } 

        public async Task<InterviewerInterview> AssignInterviewer(int interviewId, int interviewerId){
            return await _repository.AssignInterviewer(interviewId, interviewerId);
        }

        public async Task<IEnumerable<InterviewFeedback>> AddInterviewFeedback(int interviewerInterviewId, ICollection<FeedbackRequest> feedbackRequests){
            return await _repository.AddInterviewFeedback(interviewerInterviewId, feedbackRequests);
        }
    }
}