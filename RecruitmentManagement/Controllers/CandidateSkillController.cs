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
    public class CandidateSkillController : ControllerBase
    {
        private readonly CandidateSkillService _service;

        public CandidateSkillController(CandidateSkillService service)
        {
            _service = service;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var CandidateSkills = await _service.GetAllCandidateSkills();
        //     return Ok(CandidateSkills);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var CandidateSkill = await _service.GetCandidateSkillById(id);
        //     if (CandidateSkill == null) 
        //         return NotFound("Student not found.");
        //     return Ok(CandidateSkill);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Add([FromBody] CandidateSkill CandidateSkill)
        // {
        //     if (!ModelState.IsValid) 
        //         return BadRequest(ModelState);
        //     var addedCandidateSkill = await _service.AddCandidateSkill(CandidateSkill);
        //     return CreatedAtAction(nameof(GetById), new { id = addedCandidateSkill.Id }, addedCandidateSkill);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] CandidateSkill CandidateSkill)
        // {
        //     if (id != CandidateSkill.Id) 
        //         return BadRequest("ID mismatch.");
        //     var updatedCandidateSkill = await _service.UpdateCandidateSkill(CandidateSkill);
        //     if (updatedCandidateSkill == null) 
        //         return NotFound("Student not found.");
        //     return Ok(updatedCandidateSkill);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var deleted = await _service.DeleteCandidateSkill(id);
        //     if (!deleted) 
        //         return NotFound("CandidateSkill not found.");
        //     return Ok("CandidateSkill deleted successfully.");
        // }
         [HttpPost("{candidateId}")]
        [Route("markSkills")]
        public async Task<IActionResult> MarkSkills(int candidateId, [FromBody] ICollection<MarkCandidateSkill> skills)
        {
            _service.MarkSkills(candidateId, skills);
           return Ok("Candidate skills are successfull marked");
        }
        
    }
}
