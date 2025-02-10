using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using ExcelDataReader;
using RecruitmentProcessManagementSystem.Data;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShortlistCandidateController : ControllerBase
    {
        private readonly ShortlistCandidateService _service;
        private readonly RecruitmentDbContext _context;

        public ShortlistCandidateController(ShortlistCandidateService service, RecruitmentDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ShortlistCandidates = await _service.GetAllShortlistCandidates();
            if (ShortlistCandidates == null)
            {
                return NotFound("There are no candidates");
            }
            return Ok(ShortlistCandidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ShortlistCandidate = await _service.GetShortlistCandidateById(id);
            if (ShortlistCandidate == null)
                return NotFound("Student not found.");
            return Ok(ShortlistCandidate);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShortlistCandidateDTO ShortlistCandidate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedShortlistCandidate = await _service.AddShortlistCandidate(ShortlistCandidate);
            return CreatedAtAction(nameof(GetById), new { id = addedShortlistCandidate.ShortlistCandidateId }, addedShortlistCandidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShortlistCandidateDTO ShortlistCandidate)
        {
            var updatedShortlistCandidate = await _service.UpdateShortlistCandidate(id, ShortlistCandidate);
            if (updatedShortlistCandidate == null)
                return NotFound("Student not found.");
            return Ok(updatedShortlistCandidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteShortlistCandidate(id);
            if (!deleted)
                return NotFound("ShortlistCandidate not found.");
            return Ok("ShortlistCandidate deleted successfully.");
        }
    }
}
