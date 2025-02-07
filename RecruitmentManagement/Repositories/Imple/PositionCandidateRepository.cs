using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PositionCandidate> ApplyToPosition(int candidateId, int positionId)
        {
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
                ApplicationDate = DateTime.Now
            };

            await _context.PositionCandidates.AddAsync(positionCandidate);
            await _context.SaveChangesAsync();

            return positionCandidate;
        }


        public async Task<PositionCandidate> UpdatePositionCandidate(PositionCandidate PositionCandidate)
        {
            _context.PositionCandidates.Update(PositionCandidate);
            await _context.SaveChangesAsync();
            return PositionCandidate;
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

            _context.PositionCandidates.Update(PositionCandidate);
            await _context.SaveChangesAsync();
            return PositionCandidate;


        }

    }
}
