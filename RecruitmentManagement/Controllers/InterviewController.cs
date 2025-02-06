using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
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
        public async Task<IActionResult> Add([FromBody] Interview Interview)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var addedInterview = await _service.AddInterview(Interview);
            return CreatedAtAction(nameof(GetById), new { id = addedInterview.Id }, addedInterview);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Interview Interview)
        {
            if (id != Interview.Id) 
                return BadRequest("ID mismatch.");
            var updatedInterview = await _service.UpdateInterview(Interview);
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
    }
}
