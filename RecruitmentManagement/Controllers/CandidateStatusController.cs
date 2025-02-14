using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateStatusController : ControllerBase
    {
        private readonly CandidateStatusService _service;

        public CandidateStatusController(CandidateStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var CandidateStatuss = await _service.GetAllCandidateStatuss();
            if(CandidateStatuss==null){
                return NotFound("There are no CandidateStatuss");
            }
            return Ok(CandidateStatuss);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var CandidateStatus = await _service.GetCandidateStatusById(id);
            if (CandidateStatus == null)
                return NotFound("Student not found.");
            return Ok(CandidateStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CandidateStatus CandidateStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedCandidateStatus = await _service.AddCandidateStatus(CandidateStatus);
            return CreatedAtAction(nameof(GetById), new { id = addedCandidateStatus.CandidateStatusId }, addedCandidateStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CandidateStatusDTO CandidateStatus)
        {
            var updatedCandidateStatus = await _service.UpdateCandidateStatus(id, CandidateStatus);
            if (updatedCandidateStatus == null)
                return NotFound("Student not found.");
            return Ok(updatedCandidateStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCandidateStatus(id);
            if (!deleted)
                return NotFound("CandidateStatus not found.");
            return Ok("CandidateStatus deleted successfully.");
        }

        // public async Task<IActionResult> ReviewCandidateStatus(int CandidateStatusId, bool isShortlisted, [FromBody] ICollection<MarkCandidateStatusSkill> markCandidateStatusSkills){

        // }
        [HttpGet("getCandidateStatusTypes")]
        public async Task<IEnumerable<CandidateStatusType>> GetCandidateStatusTypes()
        {
            return await _service.GetCandidateStatusTypes();
        }

        [HttpGet("getCandidateStatusFromIds/{candidateId}/{positionId}")]
        public async Task<IActionResult> GetCandidateStatusFromIds(int candidateId, int positionId){
            if(positionId<=0 || candidateId<=0){
                  return NotFound("Please specify correct IDs");
            }
            var candidateStatus=await _service.GetCandidateStatusFromIds(candidateId, positionId);
            if(candidateStatus==null){
                return NotFound("Candidate Status is not found");
            }
            return Ok(candidateStatus);
         }
    }
}
