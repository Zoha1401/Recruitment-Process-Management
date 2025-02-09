using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IInterviewFeedbackRepository
    {
        Task<IEnumerable<InterviewFeedback>> GetAllInterviewFeedbacks();
        Task<InterviewFeedback> GetInterviewFeedbackById(int id);
        Task<InterviewFeedback> UpdateInterviewFeedback(int interviewid, FeedbackRequest InterviewFeedback);
        Task<bool> DeleteInterviewFeedback(int id);

      

        Task<IEnumerable<InterviewFeedback>> AddInterviewFeedback(int interviewId, ICollection<FeedbackRequest> feedbackRequests);
        
    }
}