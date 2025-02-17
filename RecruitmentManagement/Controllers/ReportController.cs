using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using Microsoft.AspNetCore.JsonPatch;
using RecruitmentProcessManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;

        public ReportController(RecruitmentDbContext context)
        {
            _context = context;
        }
        [HttpGet("fetchPositionReport/{positionId}")]

        public async Task<IActionResult> FetchPositionReport(int positionId)
        {
             var positionReport = await (from p in _context.Positions
                                        join pc in _context.PositionCandidates on p.PositionId equals pc.PositionId
                                        join c in _context.Candidates on pc.CandidateId equals c.CandidateId
                                        join u in _context.Users on c.UserId equals u.UserId
                                        where p.PositionId == positionId
                                        select new PositionReport
                                        {
                                            CandidateName = u.FirstName + u.LastName,
                                            CandidateEmail = u.Email,
                                            WorkExperience = c.WorkExperience,
                                            ResumeUrl = c.ResumeUrl,
                                            Comments = pc.Comments,
                                            IsReviewed = pc.IsReviewed,
                                            IsShortlisted = pc.IsShortlisted,
                                            ApplicationDate = pc.ApplicationDate
                                        }).ToListAsync();
            if (positionReport == null)
            {
                return NotFound("Position Report not found");
            }
            return Ok(positionReport);
        }

        [HttpGet("fetchCollegewiseReport/{positionId}")]

        public async Task<IActionResult> FetchCollegewiseReport(int positionId)
        {
            var collegewiseReport = await (from p in _context.Positions
                                           join pc in _context.PositionCandidates on p.PositionId equals pc.PositionId
                                           join c in _context.Candidates on pc.CandidateId equals c.CandidateId
                                           join u in _context.Users on c.UserId equals u.UserId
                                           where p.PositionId == positionId
                                           select new CollegewiseReport
                                           {
                                               CandidateName = u.FirstName + u.LastName,
                                               CandidateEmail = u.Email,
                                               CollegeName = c.CollegeName,
                                               WorkExperience = c.WorkExperience,
                                               ResumeUrl = c.ResumeUrl,
                                               Comments = pc.Comments,
                                               IsReviewed = pc.IsReviewed,
                                               IsShortlisted = pc.IsShortlisted,
                                               ApplicationDate = pc.ApplicationDate
                                           }).ToListAsync();
            if (collegewiseReport == null)
            {
                return NotFound("Position Report not found");
            }
            return Ok(collegewiseReport);
        }

        [HttpGet("fetchTechnologyWiseProfile")]
        public async Task<IActionResult> FetchTechnologyWiseProfile()
        {
             var technologywiseReport = await (from u in _context.Users
                                        join c in _context.Candidates on u.UserId equals c.UserId
                                        join cs in _context.CandidateSkills on c.CandidateId equals cs.CandidateId  
                                        
                                        join s in _context.Skills on cs.SkillId equals s.SkillId 
                                        orderby s.Name
                                        select new TechnologywiseReport
                                        {
                                            CandidateName = u.FirstName + u.LastName,
                                            CandidateEmail = u.Email,
                                            WorkExperience = c.WorkExperience,
                                            ResumeUrl = c.ResumeUrl,
                                            CollegeName=c.CollegeName,
                                            SkillName=s.Name,
                                            Experience=cs.Experience,
                                            Phone=u.Phone
                                        }).ToListAsync();
            if (technologywiseReport == null)
            {
                return NotFound("Position Report not found");
            }
            return Ok(technologywiseReport);
        }


        [HttpGet("fetchExperienceWiseList")]
        public async Task<IActionResult> FetchExperienceWiseList()
        {
             var experienceWiseReport = await (from u in _context.Users
                                        join c in _context.Candidates on u.UserId equals c.UserId
                                        join cs in _context.CandidateSkills on c.CandidateId equals cs.CandidateId  
                                        join s in _context.Skills on cs.SkillId equals s.SkillId 
                                        orderby s.Name, c.WorkExperience descending
                                        select new TechnologywiseReport
                                        {
                                            CandidateName = u.FirstName + u.LastName,
                                            CandidateEmail = u.Email,
                                            WorkExperience = c.WorkExperience,
                                            ResumeUrl = c.ResumeUrl,
                                            CollegeName=c.CollegeName,
                                            SkillName=s.Name,
                                            Experience=cs.Experience,
                                            Phone=u.Phone
                                        }).ToListAsync();
            if (experienceWiseReport == null)
            {
                return NotFound("Position Report not found");
            }
            return Ok(experienceWiseReport);
        }

    }
}