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
            var positionCandidate=_context.PositionCandidates.Find(Interview.PositionCandidateId);
            if(positionCandidate==null){
                throw new Exception("Candidate for this position is not found");
            }
            if(positionCandidate.IsShortlisted!=true){
                throw new Exception("The candidate is not shortlisted to be assigned an interview");
            }
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

     public async Task<Interview> UpdateInterview(int interviewId, InterviewRequest interviewRequest)
{
    var interview = await _context.Interviews.FindAsync(interviewId);

    if (interview == null)
    {
        throw new ArgumentException("Interview not found.");
    }

    if (interviewRequest.Date != default(DateTime))  
        interview.Date = interviewRequest.Date;

    if (interviewRequest.RecruiterId > 0)  
        interview.RecruiterId = interviewRequest.RecruiterId;

    if (interviewRequest.PositionCandidateId > 0)  
        interview.PositionCandidateId = interviewRequest.PositionCandidateId;

    if (interviewRequest.InterviewTypeId > 0)  
        interview.InterviewTypeId = interviewRequest.InterviewTypeId;

    if (interviewRequest.RoundNumber > 0)  
        interview.RoundNumber = interviewRequest.RoundNumber;

    _context.Interviews.Update(interview);
    await _context.SaveChangesAsync();

    return interview;
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
             if (interviewer == null)
            {
                throw new ArgumentException("The interviewer with this ID is not found");
            }
            var Role=_context.Roles.Find(interviewer.RoleId) ?? throw new ArgumentException("Role is not assigned to this ID");
            var roleName=Role.RoleName;
            if(roleName!="Interviewer"){
                throw new ArgumentException("The given user is not an interviewer");
            }
            var interview = _context.Interviews.Find(interviewId) ?? throw new ArgumentException("Position not found with this ID");
           
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

          public async Task<IEnumerable<Interview>> GetInterviewsForInterviewer(int interviewerId)
        {
            var interviewInterviewers=await _context.InterviewerInterviews.ToListAsync();
            var selected=interviewInterviewers.FindAll(ii=> ii.InterviewerId==interviewerId);
            var interviewerInterviews=await (from ii in _context.InterviewerInterviews
                                        join i in _context.Interviews on ii.InterviewId equals i.InterviewId
                                        join u in _context.Users on ii.InterviewerId equals u.UserId 
                                        select new Interview
                                        {
                                            InterviewTypeId=i.InterviewTypeId,
                                            RecruiterId=i.RecruiterId,
                                            Date=i.Date,
                                            PositionCandidateId=i.PositionCandidateId,
                                            RoundNumber=i.RoundNumber
                                        }).ToListAsync();

            if(interviewerInterviews==null){
                throw new Exception("There are no interviews");
            }

            return interviewerInterviews;
        }
    }


}