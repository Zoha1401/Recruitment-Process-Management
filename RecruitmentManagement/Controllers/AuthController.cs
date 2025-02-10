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
    public class AuthController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthController(RecruitmentDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                return BadRequest("User already exists.");

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == request.RoleId);
            if (role == null)
                return BadRequest("Invalid role.");

            var passwordHash = ComputeSha256Hash(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate,
                Password = passwordHash,
                Phone = request.Phone,
                RoleId = request.RoleId
            };
            user.Role = role;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (role.RoleName.Equals("candidate", StringComparison.CurrentCultureIgnoreCase))
            {
                var candidate = new Candidate
                {
                    UserId = user.UserId, // Link to User
                    CollegeName = request.CollegeName,
                    Degree = request.Degree,
                    WorkExperience = request.WorkExperience,
                    ResumeUrl = request.ResumeUrl
                };

                _context.Candidates.Add(candidate);
                await _context.SaveChangesAsync();
            }
            return Ok("User added successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
                return Unauthorized("Invalid email or password.");

            var passwordHash = ComputeSha256Hash(request.Password);
            if (user.Password != passwordHash)
                return Unauthorized("Invalid email or password.");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
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
