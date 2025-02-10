using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Helpers;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;
        private readonly IJwtService _jwtService;

        public UserController(RecruitmentDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserRequest request)
        {
            var user= await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if(user==null){
                return NotFound("The user with this email or id is not found");
            }
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == request.RoleId);
            if (role == null)
                return BadRequest("Invalid role.");

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.BirthDate = request.BirthDate;
                user.Phone = request.Phone;
                user.RoleId = request.RoleId;
        
            user.Role = role;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            if (role.RoleName.Equals("candidate", StringComparison.CurrentCultureIgnoreCase))
            {
                var candidate=await _context.Candidates.FirstOrDefaultAsync(c=>c.UserId==userId);
            
            if(candidate==null){
                return NotFound("Candidate is not linked with the given user ID");
            }
                    candidate.CollegeName = request.CollegeName;
                    candidate.Degree = request.Degree;
                    candidate.WorkExperience = request.WorkExperience;
                    candidate.ResumeUrl = request.ResumeUrl;


                _context.Candidates.Update(candidate);
                await _context.SaveChangesAsync();
            }



            return Ok("User updated successfully");
        }



        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("getAllReviewers")]
        public async Task<IActionResult> GetAllReviewers()
        {
            var users = await _context.Users.ToListAsync();
            var role=await _context.Roles.FirstOrDefaultAsync(r=> r.RoleName=="Reviewer");
            if(role==null){
                throw new Exception("Role not found");
            }
            var reviewers=users.FindAll(u=> u.RoleId==role.RoleId);
            return Ok(reviewers);
        }


        [HttpGet("getAllInterviewers")]
        public async Task<IActionResult> GetAllInterviewers()
        {
            var users = await _context.Users.ToListAsync();
            var role=await _context.Roles.FirstOrDefaultAsync(r=> r.RoleName=="Interviewer");
            if(role==null){
                throw new Exception("Role not found");
            }
            var interviewers=users.FindAll(u=> u.RoleId==role.RoleId);
            return Ok(interviewers);
        }

        [HttpDelete("{userId}")]

        public async Task<bool> DeleteUser(int userId)
        {
            var User = await _context.Users.FindAsync(userId);
            if (User == null) return false;

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
