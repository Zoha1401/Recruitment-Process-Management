using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using ExcelDataReader;
using RecruitmentProcessManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _service;
        //private readonly RecruitmentDbContext _context;

        public CandidateController(CandidateService service)
        {
            _service = service;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Candidates = await _service.GetAllCandidates();
            if (Candidates == null)
            {
                return NotFound("There are no candidates");
            }
            return Ok(Candidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Candidate = await _service.GetCandidateById(id);
            if (Candidate == null)
                return NotFound("Student not found.");
            return Ok(Candidate);
        }

        // [HttpPost]
        // public async Task<IActionResult> Add([FromBody] Candidate Candidate)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var addedCandidate = await _service.AddCandidate(Candidate);
        //     return CreatedAtAction(nameof(GetById), new { id = addedCandidate.CandidateId }, addedCandidate);
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Candidate Candidate)
        {
            if (id != Candidate.CandidateId)
                return BadRequest("ID mismatch.");
            var updatedCandidate = await _service.UpdateCandidate(Candidate);
            if (updatedCandidate == null)
                return NotFound("Student not found.");
            return Ok(updatedCandidate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteCandidate(id);
            if (!deleted)
                return NotFound("Candidate not found.");
            return Ok("Candidate deleted successfully.");
        }

        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var candidates=await _service.BulkUpload(file);
            return Ok(new { message = "Candidates uploaded successfully!", candidates });
        }


        // public async Task<IActionResult> ReviewCandidate(int candidateId, bool isShortlisted, [FromBody] ICollection<MarkCandidateSkill> markCandidateSkills){

        // }

        
       
    }
}
