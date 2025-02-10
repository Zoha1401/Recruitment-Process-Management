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
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _service;
        private readonly RecruitmentDbContext _context;

        public CandidateController(CandidateService service, RecruitmentDbContext context)
        {
            _service = service;
            _context = context;
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
        public async Task<IActionResult> Add([FromBody] Candidate Candidate)
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

        // [HttpPost("bulk-upload")]
        // public async Task<IActionResult> BulkUpload(IFormFile file)
        // {
        //     if (file == null || file.Length == 0)
        //         return BadRequest("No file uploaded");

        //     var candidates = new List<Candidate>();
        //     var users = new List<User>();

        //     using (var stream = file.OpenReadStream())
        //     {
        //         System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //         using (var reader = ExcelReaderFactory.CreateReader(stream))
        //         {
        //             var result = reader.AsDataSet();
        //             var dataTable = result.Tables[0];

        //             for (int i = 1; i < dataTable.Rows.Count; i++) // Skip header row
        //             {
        //                 var row = dataTable.Rows[i];
        //                 var email = row[2].ToString();

        //                 if (await _context.Users.AnyAsync(u => u.Email == email))
        //                     continue; // Skip duplicate emails

        //                 var user = new User
        //                 {
        //                     Email = email,
        //                     Password = HashPassword("Default@123"), // Set default hashed password
        //                     Role = "Candidate"
        //                 };

        //                 users.Add(user);
        //                 await _context.SaveChangesAsync();

        //                 var candidate = new Candidate
        //                 {
        //                     UserId = user.UserId, // Link with User
        //                     Name = row[0].ToString(),
        //                     CollegeName = row[1].ToString(),
        //                     Degree = row[3].ToString(),
        //                     WorkExperience = float.Parse(row[4].ToString()),
        //                     ResumeUrl = row[5].ToString()
        //                 };

        //                 candidates.Add(candidate);
        //             }
        //         }
        //     }

        //     if (candidates.Count > 0)
        //     {
        //         await _context.Candidates.AddRangeAsync(candidates);
        //         await _context.SaveChangesAsync();
        //     }

        //     return Ok(new { message = "Candidates uploaded successfully!", count = candidates.Count });
        // }


        // public async Task<IActionResult> ReviewCandidate(int candidateId, bool isShortlisted, [FromBody] ICollection<MarkCandidateSkill> markCandidateSkills){

        // }
    }
}
