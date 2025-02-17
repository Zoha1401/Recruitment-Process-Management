using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using Microsoft.AspNetCore.Cors;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    // [Authorize(Policy = "InterviewerPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly InterviewService _service;

        public InterviewController(InterviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Interviews = await _service.GetAllInterviews();
            if(Interviews==null){
                return NotFound("There are no interviews scheduled");
            }
            return Ok(Interviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Interview = await _service.GetInterviewById(id);
            if (Interview == null) 
                return NotFound("Student not found.");
            return Ok(Interview);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InterviewRequest Interview)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var addedInterview = await _service.AddInterview(Interview);
            return CreatedAtAction(nameof(GetById), new { id = addedInterview.InterviewId }, addedInterview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InterviewRequest Interview)
        {
            var updatedInterview = await _service.UpdateInterview(id, Interview);
            if (updatedInterview == null) 
                return NotFound("Student not found.");
            return Ok(updatedInterview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteInterview(id);
            if (!deleted) 
                return NotFound("Interview not found.");
            return Ok("Interview deleted successfully.");
        }
        //Assign Interviewer to an Interview
        
        [HttpPost("assignInterviewer/{interviewId}/{interviewerId}")]
        public async Task<IActionResult> AssignInterviewer(int interviewId, int interviewerId){
            var InterviewerInterview=await _service.AssignInterviewer(interviewId, interviewerId);
            if(InterviewerInterview==null){
                return NotFound("There was problem in assigning interviewer.Please try again");
            }
            return Ok(InterviewerInterview);
        }

        // [HttpPost("addInterviewFeedback/{interviewerInterviewId}")]
        // public async Task<IActionResult> AddInterviewFeedback(int interviewerInterviewId, [FromBody] ICollection<FeedbackRequest> feedbackRequests){
        //    IEnumerable<InterviewFeedback> feedbacks=await _service.AddInterviewFeedback(interviewerInterviewId, feedbackRequests);
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //    return Ok(feedbacks);
        // }
        [Authorize(Policy = "InterviewerPolicy")]
        [HttpGet("getInterviewsForInterviewer/{interviewerId}")]
        public async Task<IEnumerable<Interview>> GetInterviewsForInterviewer(int interviewerId)
        {
            return await _service.GetInterviewsForInterviewer(interviewerId);
        }
        [HttpGet("getInterviewerInterview/{interviewId}/{interviewerId}")]
        public async Task<IActionResult> GetInterviewerInterview(int interviewId, int interviewerId){
            var interviewerInterview= await _service.GetInterviewerInterview(interviewId, interviewerId);
            if(interviewerInterview==null){
                return NotFound("Interview for this interviewer not found");
            }
            return Ok(interviewerInterview);
         }

        [HttpPost("assignInterviews/{interviewId}")]
         public async Task<IActionResult> AssignInterviewers(int interviewId, ICollection<Interviewer> assignInterviews){
            var InterviewerInterviews=await _service.AssignInterviewers(interviewId, assignInterviews);
            return Ok(InterviewerInterviews);
         }

        [HttpGet("getCandidateDoneInterviews/{positionCandidateId}")]
        public async Task<IEnumerable<CandidateInterview>> GetCandidateDoneInterviews(int positionCandidateId){
            if(positionCandidateId<=0){
                throw new Exception("Please provide correct position candidate ID");
            }
            return await _service.GetCandidateDoneInterviews(positionCandidateId);
          }


        [HttpGet("getAssignedInterviewers/{interviewId}")]
        public async Task<IEnumerable<Interviewer>> GetAssignedInterviewers(int interviewId){
                return await _service.GetAssignedInterviewers(interviewId);
            }

    
    }
}
