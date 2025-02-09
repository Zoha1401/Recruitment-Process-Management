using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class InterviewFeedbackService
    {
        private readonly IInterviewFeedbackRepository _repository;

        public InterviewFeedbackService(IInterviewFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InterviewFeedback>> GetAllInterviewFeedbacks() {
            return await _repository.GetAllInterviewFeedbacks();
        } 
        public async Task<InterviewFeedback> GetInterviewFeedbackById(int id) {
            return await _repository.GetInterviewFeedbackById(id);
        }
        public async Task<InterviewFeedback> UpdateInterviewFeedback(int interviewId, FeedbackRequest InterviewFeedback) {
            return await _repository.UpdateInterviewFeedback(interviewId, InterviewFeedback);
        } 
    
        public async Task<bool> DeleteInterviewFeedback(int id) {
            return await _repository.DeleteInterviewFeedback(id);
        } 


        public async Task<IEnumerable<InterviewFeedback>> AddInterviewFeedback(int interviewerInterviewId, ICollection<FeedbackRequest> feedbackRequests){
            return await _repository.AddInterviewFeedback(interviewerInterviewId, feedbackRequests);
        }
    }
}