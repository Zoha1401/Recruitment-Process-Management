using Microsoft.AspNetCore.Mvc;

using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Service;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "HRPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly SkillService _service;

        public SkillController(SkillService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Skills = await _service.GetAllSkills();
            if(Skills==null){
                return NotFound("There are no relevant skills found");
            }
            return Ok(Skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Skill = await _service.GetSkillById(id);
            if (Skill == null) 
                return NotFound("Student not found.");
            return Ok(Skill);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Skill Skill)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var addedSkill = await _service.AddSkill(Skill);
            return CreatedAtAction(nameof(GetById), new { id = addedSkill.SkillId }, addedSkill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Skill Skill)
        {
            if (id != Skill.SkillId) 
                return BadRequest("ID mismatch.");
            var updatedSkill = await _service.UpdateSkill(Skill);
            if (updatedSkill == null) 
                return NotFound("Student not found.");
            return Ok(updatedSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteSkill(id);
            if (!deleted) 
                return NotFound("Skill not found.");
            return Ok("Skill deleted successfully.");
        }
    }
}
