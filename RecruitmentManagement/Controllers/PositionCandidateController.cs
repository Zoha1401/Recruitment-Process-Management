using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "ReviewerPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionCandidateController : ControllerBase
    {
        private readonly PositionCandidateService _service;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PositionCandidate PositionCandidate)
        {
            if (id != PositionCandidate.Id)
                return BadRequest("ID mismatch.");
            var updatedPositionCandidate = await _service.UpdatePositionCandidate(PositionCandidate);
            if (updatedPositionCandidate == null)
                return NotFound("Student not found.");
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
        [HttpPost("applyToPosition/{candidateId}/{positionId}")]
        public async Task<IActionResult> ApplyToPosition(int candidateId, int positionId){
            var PositionCandidate=await _service.ApplyToPosition(candidateId, positionId);
            if(PositionCandidate==null){
                return NotFound("The position candidate was not found");
            }
            return Ok(PositionCandidate);
        }
    }
}
