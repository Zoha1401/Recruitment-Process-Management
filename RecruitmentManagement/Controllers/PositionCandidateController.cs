using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using RecruitmentManagement.DTOs;
using System.Security.Claims;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "ReviewerPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionCandidateController : ControllerBase
    {
        private readonly PositionCandidateService _service;
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PositionCandidateController(PositionCandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PositionCandidates = await _service.GetAllPositionCandidates();
            if(PositionCandidates==null){
                return NotFound("No candidates has applied for any position");
            }
            return Ok(PositionCandidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var PositionCandidate = await _service.GetPositionCandidateById(id);
            if (PositionCandidate == null)
                return NotFound("Student not found.");
            return Ok(PositionCandidate);
        }

        // [HttpPost]
        // public async Task<IActionResult> Add([FromBody] PositionCandidate PositionCandidate)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var addedPositionCandidate = await _service.AddPositionCandidate(PositionCandidate);
        //     return CreatedAtAction(nameof(GetById), new { id = addedPositionCandidate.Id }, addedPositionCandidate);
        // }

        [HttpPut("{positionCandidateId}")]
        public async Task<IActionResult> Update(int positionCandidateId, [FromBody] PositionCandidateDTO PositionCandidate)
        {
            var updatedPositionCandidate = await _service.UpdatePositionCandidate(positionCandidateId, PositionCandidate);
            if (updatedPositionCandidate == null)
                return NotFound("PositionCandidate not found.");
            return Ok(updatedPositionCandidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeletePositionCandidate(id);
            if (!deleted)
                return NotFound("PositionCandidate not found.");
            return Ok("PositionCandidate deleted successfully.");
        }

        [HttpPost("reviewCandidate/{PositionCandidateId}/{isShortlisted}")]
        public async Task<IActionResult> ReviewPositionCandidate(int PositionCandidateId, bool isShortlisted, [FromBody] ICollection<MarkCandidateSkill> MarkCandidateSkills){
            var PositionCandidate=await _service.ReviewPositionCandidate(PositionCandidateId, isShortlisted, MarkCandidateSkills );
            if(PositionCandidate==null){
                return NotFound("PositionCandidate Not found");
            }
            return Ok(PositionCandidate);
        }
        [HttpPost("applyToPosition/{candidateId}/{positionId}/{statusId}/{userId}")]
        public async Task<IActionResult> ApplyToPosition(int userId, int candidateId, int positionId,int statusId){
          
            // var httpContext = _httpContextAccessor?.HttpContext;
            // if (httpContext == null)
            // {
            //     throw new Exception("HttpContext is null. Ensure request is within an HTTP context.");
            // }

            // var user = httpContext.User;
            // if (user == null || !user.Identity.IsAuthenticated)
            // {
            //     throw new Exception("User is not authenticated.");
            // }
            // var userIdString = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (string.IsNullOrEmpty(userIdString))
            // {
            //     throw new Exception("User ID claim ('NameIdentifier') not found.");
            // }

            // int userId = int.TryParse(userIdString, out int parsedUserId) ? parsedUserId : throw new Exception("Invalid user ID format.");

            var PositionCandidate=await _service.ApplyToPosition(userId, candidateId, positionId, statusId);
            if(PositionCandidate==null){
                return NotFound("The position candidate was not found");
            }
            return Ok(PositionCandidate);
        }

        // [HttpGet("viewApplicants/{positionId}")]
        // public async Task<IActionResult> ViewApplicants(int positionId){
        //     var 
        // }
    }
}
