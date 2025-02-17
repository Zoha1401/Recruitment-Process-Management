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
    [Authorize(Policy ="RecruiterCandidatePolicy")]
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CandidateDTO Candidate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedCandidate = await _service.AddCandidate(Candidate);
            return CreatedAtAction(nameof(GetById), new { id = addedCandidate.CandidateId }, addedCandidate);
        }

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
  
  [HttpGet("getCandidate/{userId}")]
          public async Task<Candidate> GetCandidateFromUserId(int userId){
            
            return await _service.GetCandidateFromUserId(userId);
         }

        [HttpPost("applyToPosition/{candidateId}/{positionId}")]
        public async Task<IActionResult> ApplyToPosition(int candidateId, int positionId)
        {

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

            var PositionCandidate = await _service.ApplyToPosition(candidateId, positionId);
            if (PositionCandidate == null)
            {
                return NotFound("The position candidate was not found");
            }
            return Ok(PositionCandidate);

            
        }

        // [Authorize]
        [AllowAnonymous]
        [HttpPost("uploadResume")]
        public async Task<ActionResult<string>> GetResumeLink(IFormFile formFile){
            // Console.WriteLine(Path.GetExtension(formFile.FileName));
            var extension = Path.GetExtension(formFile.FileName);
            if(formFile.Length>0 && ((extension == ".docx") || (extension ==".pdf"))){
                var filePath = Path.Combine("Resources","Resume",formFile.FileName);
                using(var stream = new FileStream(filePath,FileMode.Create)){
                    await formFile.CopyToAsync(stream);
                }
                return filePath;
            }else{
                return BadRequest("Invalid file format");
            }
        }


        [HttpPost("uploadDocument")]
        public async Task<ActionResult<string>> GetDocumentLink(IFormFile formFile){
            // Console.WriteLine(Path.GetExtension(formFile.FileName));
            var extension = Path.GetExtension(formFile.FileName);
            if(formFile.Length>0 && ((extension == ".docx") || (extension ==".pdf") || (extension==".jpg") || (extension==".png"))){
                var filePath = Path.Combine("Resources","Documents",formFile.FileName);
                using(var stream = new FileStream(filePath,FileMode.Create)){
                    await formFile.CopyToAsync(stream);
                }
                return filePath;
            }else{
                return BadRequest("Invalid file format");
            }
        }

        [HttpGet("getCandidates")]
         public async Task<IActionResult> GetCandidates(){
            var candidates=await _service.GetCandidates();
            return Ok(candidates);
         }


        
       
    }
}
