using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly RecruitmentDbContext _context;

        public InterviewRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interview>> GetAllInterviews()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task<Interview> GetInterviewById(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }

        public async Task<Interview> AddInterview(InterviewRequest Interview)
        {
            
            var newInterview = new Interview
            {
                Date = Interview.Date,
                RecruiterId = Interview.RecruiterId,
                PositionCandidateId = Interview.PositionCandidateId,
                InterviewTypeId = Interview.InterviewTypeId,
                RoundNumber = Interview.RoundNumber
            };
            _context.Interviews.Add(newInterview);
            await _context.SaveChangesAsync();
            return newInterview;
        }

        public async Task<Interview> UpdateInterview(Interview Interview)
        {
            _context.Interviews.Update(Interview);
            await _context.SaveChangesAsync();
            return Interview;
        }

        public async Task<bool> DeleteInterview(int id)
        {
            var Interview = await _context.Interviews.FindAsync(id);
            if (Interview == null) return false;

            _context.Interviews.Remove(Interview);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<InterviewerInterview> AssignInterviewer(int interviewId, int interviewerId)
        {
            var interviewer = _context.Users.Find(interviewerId) ?? throw new ArgumentException("Interviewer is not found by this ID");
            // if(interviewer.Role.RoleName!= _context.Roles.FirstOrDefaultAsync(r=> r.RoleName))
            // var role=_context.Users.FirstOrDefault(u => u.Role.RoleName=="Interviewer");
            if(interviewer.Role.RoleName!="Interviewer"){
                throw new ArgumentException("The given user is not an interviewer");
            }
            var interview = _context.Interviews.Find(interviewId) ?? throw new ArgumentException("Position not found with this ID");
            if (interviewer == null)
            {
                throw new ArgumentException("The interviewer with this ID is not found");
            }
            if (interview == null)
            {
                throw new ArgumentException("The interview with this ID is not found");
            }

            var InterviewerInterview = new InterviewerInterview
            {
                InterviewerId = interviewerId,
                InterviewId = interviewId
            };

            _context.InterviewerInterviews.Add(InterviewerInterview);
            await _context.SaveChangesAsync();

            return InterviewerInterview;

        }

        public async Task<IEnumerable<InterviewFeedback>> AddInterviewFeedback(int interviewerInterviewId, ICollection<FeedbackRequest> feedbackRequests){
            var interviewerInterview= await _context.InterviewerInterviews.FindAsync(interviewerInterviewId);
            if(interviewerInterview==null){
                throw new ArgumentException("Interviewer for the this interview is not found");
            }

            if(feedbackRequests!=null){
                foreach(FeedbackRequest feedbackRequest in feedbackRequests){
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
    }


}