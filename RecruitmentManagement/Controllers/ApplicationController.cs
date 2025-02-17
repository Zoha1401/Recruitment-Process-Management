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
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;

        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var Applications = await _service.GetAllApplications();
        //     return Ok(Applications);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var Application = await _service.GetApplicationById(id);
        //     if (Application == null) 
        //         return NotFound("Student not found.");
        //     return Ok(Application);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Add([FromBody] Application Application)
        // {
        //     if (!ModelState.IsValid) 
        //         return BadRequest(ModelState);
        //     var addedApplication = await _service.AddApplication(Application);
        //     return CreatedAtAction(nameof(GetById), new { id = addedApplication.Id }, addedApplication);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Application Application)
        // {
        //     if (id != Application.Id) 
        //         return BadRequest("ID mismatch.");
        //     var updatedApplication = await _service.UpdateApplication(Application);
        //     if (updatedApplication == null) 
        //         return NotFound("Student not found.");
        //     return Ok(updatedApplication);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var deleted = await _service.DeleteApplication(id);
        //     if (!deleted) 
        //         return NotFound("Application not found.");
        //     return Ok("Application deleted successfully.");
        // }
        
        [HttpPost("{candidateId}/{positionId}")]
        public async Task<IActionResult> ApplyToPosition(int candidateId, int positionId){
            _service.ApplyToPosition(candidateId, positionId);
            return Ok("Successfully applied to the position");

        }
    }
}
