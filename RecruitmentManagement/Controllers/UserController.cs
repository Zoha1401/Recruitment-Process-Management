using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Helpers;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;
        private readonly IJwtService _jwtService;
         private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(RecruitmentDbContext context, IJwtService jwtService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
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

        [HttpGet("getUser/{userId}")]
          public async Task<IActionResult> GetUser(int userId)
        {
            var User = await _context.Users.FirstOrDefaultAsync(u=> u.UserId==userId);
            if (User == null) return NotFound("User was not found");
            return Ok(User);
        }

         [HttpGet("getUserByEmail/{email}")]
          public async Task<IActionResult> GetUser(string email)
        {
            var User = await _context.Users.FirstOrDefaultAsync(u=> u.Email==email);
            if (User == null) return NotFound("User was not found");
            return Ok(User);
        }

    [HttpGet("me")]
    public IActionResult GetUserFromToken()
    {
        var cookie =_httpContextAccessor.HttpContext.Request.Cookies["token"];

        if (string.IsNullOrEmpty(cookie))
        {
            return NotFound(new {message="Cookie is empty"});
        }

       var tokenHandler = new JwtSecurityTokenHandler();
    try
    {
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")); // Use the actual key here
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true, 
            IssuerSigningKey = key,
            ValidIssuer = "RecruitmentAPI",  
            ValidAudience = "RecruitmentAPIUsers" 
        };

       
        var principal = tokenHandler.ValidateToken(cookie, validationParameters, out var validatedToken);

        if (principal == null)
        {
            return Unauthorized("Invalid or expired token.");
        }

       
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userEmail = principal.FindFirst(ClaimTypes.Email)?.Value;
        var role = principal.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new
        {
            UserId = userId,
            Email = userEmail,
            Role = role
        });
    }
    catch (SecurityTokenExpiredException)
    {
        return Unauthorized("Token has expired.");
    }
    catch (SecurityTokenException)
    {
        return Unauthorized("Invalid token.");
    }
    catch (Exception ex)
    {
        return BadRequest($"Error: {ex.Message}");
    }

    }
}
}
