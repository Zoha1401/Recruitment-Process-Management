using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class InterviewFeedbackRepository : IInterviewFeedbackRepository
    {
        private readonly RecruitmentDbContext _context;

        public InterviewFeedbackRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterviewFeedback>> GetAllInterviewFeedbacks()
        {
            return await _context.InterviewFeedbacks.ToListAsync();
        }

        public async Task<InterviewFeedback> GetInterviewFeedbackById(int id)
        {
            return await _context.InterviewFeedbacks.FindAsync(id);
        }

     public async Task<InterviewFeedback> UpdateInterviewFeedback(int interviewFeedbackId, FeedbackRequest feedbackRequest)
{
    var interviewFeedback = await _context.InterviewFeedbacks.FindAsync(interviewFeedbackId);

    if (interviewFeedback == null)
    {
        throw new ArgumentException("InterviewFeedback not found.");
    }
    if (feedbackRequest.SkillId > 0)
        interviewFeedback.SkillId = feedbackRequest.SkillId;

    if (feedbackRequest.Rating > 0)
        interviewFeedback.Rating = feedbackRequest.Rating;

    if (!string.IsNullOrWhiteSpace(feedbackRequest.Feedback))
        interviewFeedback.Feedback = feedbackRequest.Feedback;

    _context.InterviewFeedbacks.Update(interviewFeedback);
    await _context.SaveChangesAsync();

    return interviewFeedback;
}


        public async Task<bool> DeleteInterviewFeedback(int id)
        {
            var InterviewFeedback = await _context.InterviewFeedbacks.FindAsync(id);
            if (InterviewFeedback == null) return false;

            _context.InterviewFeedbacks.Remove(InterviewFeedback);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<InterviewFeedback>> AddInterviewFeedback(int interviewerInterviewId, ICollection<FeedbackRequest> feedbackRequests){
            var interviewerInterview= await _context.InterviewerInterviews.FindAsync(interviewerInterviewId);
            if(interviewerInterview==null){
                throw new ArgumentException("Interviewer for the this interview is not found");
            }

            if(feedbackRequests!=null){
                foreach(FeedbackRequest feedbackRequest in feedbackRequests){
                    // var existingFeedback=await _context.InterviewFeedbacks()
                    var interviewFeedback=new InterviewFeedback{
                        InterviewerInterviewId=interviewerInterviewId,
                        SkillId=feedbackRequest.SkillId,
                        Rating=feedbackRequest.Rating,
                        Feedback=feedbackRequest.Feedback
                    };

                    await _context.InterviewFeedbacks.AddAsync(interviewFeedback);
                }
            }
            await _context.SaveChangesAsync();
            return _context.InterviewFeedbacks;
        }

        public async  Task<IEnumerable<FeedbackRequest>> GetInterviewFeedbacks(int interviewId, int interviewerId){
            var feedbacks=await (from iif in _context.InterviewFeedbacks join ii in _context.InterviewerInterviews
                                 on iif.InterviewerInterviewId equals ii.InterviewerInterviewId 
                                 where ii.InterviewerId==interviewerId 
                                 where ii.InterviewId==interviewId
                                 select new FeedbackRequest{
                                   Feedback=iif.Feedback,
                                   SkillId=iif.SkillId,
                                   Rating=iif.Rating
                                 }
                                  ).ToListAsync();
            return feedbacks;
        }
    }


}