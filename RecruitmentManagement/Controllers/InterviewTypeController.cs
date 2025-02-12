using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Helpers;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;
        private readonly IJwtService _jwtService;

        public InterviewTypeController(RecruitmentDbContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpGet("getAllInterviewTypes")]
        public async Task<IActionResult> GetAllInterviewTypes()
        {
            var interviewTypes = await _context.InterviewTypes.ToListAsync();
            return Ok(interviewTypes);
        }

         [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interviewType = await _context.InterviewTypes.FindAsync(id);
            return Ok(interviewType);
        }

     
    }
}
