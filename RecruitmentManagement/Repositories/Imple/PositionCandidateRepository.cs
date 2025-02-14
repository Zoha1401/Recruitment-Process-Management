using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.DTOs;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class PositionCandidateRepository : IPositionCandidateRepository
    {
        private readonly RecruitmentDbContext _context;

        public PositionCandidateRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PositionCandidate>> GetAllPositionCandidates()
        {
            return await _context.PositionCandidates.ToListAsync();
        }

        public async Task<PositionCandidate> GetPositionCandidateById(int id)
        {
            return await _context.PositionCandidates.FindAsync(id);
        }

        public async Task<PositionCandidate> ApplyToPosition(int candidateId, int positionId, int statusId, int userId)
        {
            bool alreadyApplied = await _context.PositionCandidates
     .AnyAsync(pc => pc.CandidateId == candidateId && pc.PositionId == positionId);

            if (alreadyApplied)
            {
                throw new InvalidOperationException("Candidate has already applied for the position");
            }

            var candidate = _context.Candidates.Find(candidateId);
            var position = _context.Positions.Find(positionId);

            if (candidate == null || position == null)
            {
                throw new ArgumentException("Invalid candidate or position ID.");
            }
            var positionCandidate = new PositionCandidate
            {
                CandidateId = candidateId,
                PositionId = positionId,
                ApplicationDate = DateTime.Now,
                IsShortlisted=false,
                IsReviewed=false
            };

            await _context.PositionCandidates.AddAsync(positionCandidate);
            await _context.SaveChangesAsync();


            //var userId = _httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "sub");
            var candidateStatus = new CandidateStatus
            {
                PositionId = positionId,
                CandidateId = candidateId,
                StatusId = statusId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId,
            };

            await _context.CandidateStatuses.AddAsync(candidateStatus);
            await _context.SaveChangesAsync();

            return positionCandidate;
        }


        public async Task<PositionCandidate> UpdatePositionCandidate(int positionCandidateId, PositionCandidateDTO PositionCandidate)
        {
            var positionCandidate=await _context.PositionCandidates.FindAsync(positionCandidateId);
            if(positionCandidate==null){
                throw new ArgumentException("position candidate is not found");
            }
            if(PositionCandidate.ApplicationDate!=null){
                positionCandidate.ApplicationDate = PositionCandidate.ApplicationDate.Value;
            }
            if(PositionCandidate.Comments!=null){
                positionCandidate.Comments=PositionCandidate.Comments;
            }
             if(PositionCandidate.IsReviewed!=null){
                positionCandidate.IsReviewed=PositionCandidate.IsReviewed.Value;
            }
            if(PositionCandidate.IsShortlisted!=null){
                positionCandidate.IsShortlisted=PositionCandidate.IsShortlisted.Value;
            }
            if(PositionCandidate.PositionId!=null){
                positionCandidate.PositionId=PositionCandidate.PositionId.Value;
            }
              if(PositionCandidate.CandidateId!=null){
                positionCandidate.CandidateId=PositionCandidate.CandidateId.Value;
            }
            _context.PositionCandidates.Update(positionCandidate);
            await _context.SaveChangesAsync();
            return positionCandidate;
        }

        public async Task<bool> DeletePositionCandidate(int id)
        {
            var PositionCandidate = await _context.PositionCandidates.FindAsync(id);
            if (PositionCandidate == null) return false;

            _context.PositionCandidates.Remove(PositionCandidate);
            await _context.SaveChangesAsync();
            return true;
        }

        // public Task<PositionCandidate> ReviewPositionCandidate(int position_PositionCandidate_id, bool isShortlisted, ICollection<MarkCandidateSkill> markPositionCandidateSkills)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<PositionCandidate> ReviewPositionCandidate(int PositionCandidateId, bool isShortlisted, ICollection<MarkCandidateSkill> markCandidateSkills)
        {
            var PositionCandidate = await _context.PositionCandidates.FindAsync(PositionCandidateId);
            if (PositionCandidate == null)
            {
                throw new ArgumentException("The candidate has not applied for position");
            }
            if (markCandidateSkills != null)
            {
                foreach (MarkCandidateSkill markCandidateSkill in markCandidateSkills)
                {
                    var skill = await _context.Skills.FindAsync(markCandidateSkill.SkillId);
                    if (skill == null)
                    {
                        throw new ArgumentException($"Skill with ID {markCandidateSkill.SkillId} does not exist.");
                    }
                    var candidateSkill = new CandidateSkill
                    {
                        CandidateId = PositionCandidate.CandidateId,
                        SkillId = markCandidateSkill.SkillId,
                        Experience = markCandidateSkill.Experience
                    };

                    await _context.CandidateSkills.AddAsync(candidateSkill);
                }
            }
            PositionCandidate.IsShortlisted = isShortlisted;
            PositionCandidate.IsReviewed=true;

            _context.PositionCandidates.Update(PositionCandidate);
            await _context.SaveChangesAsync();
            return PositionCandidate;


        }

        public async Task<IEnumerable<CandidateDTO>> ViewApplicants(int positionId){
            var positionApplicants= await (from u in _context.Users
                                        join c in _context.Candidates on u.UserId equals c.UserId
                                        join pc in _context.PositionCandidates on c.CandidateId equals pc.CandidateId
                                        join p in _context.Positions on pc.PositionId equals p.PositionId
                                        where p.PositionId==positionId
                                        select new CandidateDTO
                                        {
                                            FirstName = u.FirstName,
                                            LastName=u.LastName,
                                            Email = u.Email,
                                            WorkExperience = c.WorkExperience,
                                            ResumeUrl = c.ResumeUrl,
                                            CollegeName=c.CollegeName,
                                            Phone=u.Phone,
                                            RoleId=u.RoleId,
                                            PositionCandidateId=pc.PositionCandidateId,
                                            Degree=c.Degree,
                                            IsShortlisted=pc.IsShortlisted,
                                            CandidateId=c.CandidateId
                                        }).ToListAsync();

            return positionApplicants;
        }


        public async Task<IEnumerable<PositionRequest>> ViewApplications(int candidateId){
            var Applications= await (from c in _context.Candidates
                                        join pc in _context.PositionCandidates on c.CandidateId equals pc.CandidateId
                                        join p in _context.Positions on pc.PositionId equals p.PositionId
                                        join cs in _context.CandidateStatuses on pc.CandidateId equals cs.CandidateId
                                        join cst in _context.CandidateStatusTypes on cs.StatusId equals cst.CandidateStatusTypeId
                                        where c.CandidateId==candidateId
                                        select new PositionRequest
                                        {
                                           Name=p.Name,
                                           MinExp=p.MinExp,
                                           MaxExp=p.MaxExp,
                                           Description=p.Description,
                                           NoOfInterviews=p.NoOfInterviews,
                                           StatusName=cst.Name,
                                           PositionId=p.PositionId
                                           
                                        }).ToListAsync();

            return Applications;
        }

        public async Task<CandidateDTO> GetCandidateDetails(int positionCandidateId){
            var CandidateDetails= await (from u in _context.Users
                                        join c in _context.Candidates on u.UserId equals c.UserId
                                        join pc in _context.PositionCandidates on c.CandidateId equals pc.CandidateId
                                        join p in _context.Positions on pc.PositionId equals p.PositionId
                                        where pc.PositionCandidateId==positionCandidateId
                                        select new CandidateDTO
                                        {
                                            FirstName = u.FirstName,
                                            LastName=u.LastName,
                                            Email = u.Email,
                                            WorkExperience = c.WorkExperience,
                                            ResumeUrl = c.ResumeUrl,
                                            CollegeName=c.CollegeName,
                                            Phone=u.Phone,
                                            Degree=c.Degree,
                                            RoleId=u.RoleId,
                                            CandidateId=c.CandidateId,
                                            IsShortlisted=pc.IsShortlisted
                                        }).FirstOrDefaultAsync();
            
            if(CandidateDetails==null){
                throw new Exception("There is no application for this Interview");
            }
            return CandidateDetails;
        }


      
    }
}
