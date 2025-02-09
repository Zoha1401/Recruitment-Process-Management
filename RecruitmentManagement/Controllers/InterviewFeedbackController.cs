using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Controllers
{
    // [Authorize(Policy = "RecruiterPolicy")]
    [Authorize(Policy = "InterviewerPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly InterviewFeedbackService _service;

        public InterviewFeedbackController(InterviewFeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var InterviewFeedbacks = await _service.GetAllInterviewFeedbacks();
            if(InterviewFeedbacks==null){
                return NotFound("There are no interviews scheduled");
            }
            return Ok(InterviewFeedbacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var InterviewFeedback = await _service.GetInterviewFeedbackById(id);
            if (InterviewFeedback == null) 
                return NotFound("Student not found.");
            return Ok(InterviewFeedback);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FeedbackRequest InterviewFeedback)
        {
            var updatedInterviewFeedback = await _service.UpdateInterviewFeedback(id, InterviewFeedback);
            if (updatedInterviewFeedback == null) 
                return NotFound("Student not found.");
            return Ok(updatedInterviewFeedback);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteInterviewFeedback(id);
            if (!deleted) 
                return NotFound("InterviewFeedback not found.");
            return Ok("InterviewFeedback deleted successfully.");
        }
        

        [HttpPost("addInterviewFeedback/{interviewerInterviewId}")]
        public async Task<IActionResult> AddInterviewFeedback(int interviewerInterviewId, [FromBody] ICollection<FeedbackRequest> feedbackRequests){
           IEnumerable<InterviewFeedback> feedbacks=await _service.AddInterviewFeedback(interviewerInterviewId, feedbackRequests);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           return Ok(feedbacks);
        }

    
    }
}
