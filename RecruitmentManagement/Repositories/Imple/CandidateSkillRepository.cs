using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class CandidateSkillRepository : ICandidateSkillRepository
    {
        private readonly RecruitmentDbContext _context;

        public CandidateSkillRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateSkill>> GetAllCandidateSkills()
        {
            return await _context.CandidateSkills.ToListAsync();
        }

        public async Task<CandidateSkill> GetCandidateSkillById(int id)
        {
            var candidate=await _context.CandidateSkills.FirstOrDefaultAsync(cs=> cs.CandidateId==id);
            if(candidate==null)
            throw new ArgumentException("Candidate with this ID is not found");
            return candidate;

        }

        public async Task<CandidateSkill> AddCandidateSkill(int candidateId, int skillId, MarkCandidateSkill candidateSkillRequest)
        {
            var candidate = await _context.Candidates.FindAsync(candidateId);
            if (candidate == null)
            {
                throw new ArgumentException("Candidate with this ID is not found");
            }
            var skill = await _context.Skills.FindAsync(skillId);
            if (skill == null)
            {
                throw new ArgumentException("skill with this ID is not found");
            }
            var candidateSkillExist = await _context.CandidateSkills
       .FirstOrDefaultAsync(cs => cs.CandidateId == candidateId && cs.SkillId == skillId);

            if (candidateSkillExist != null)
            {
                throw new ArgumentException("Skill for this ID is already present please update to change");
            }
            var candidateSkill = new CandidateSkill
            {
                CandidateId = candidateId,
                SkillId = skillId,
                Experience = candidateSkillRequest.Experience
            };

            _context.CandidateSkills.Add(candidateSkill);
            await _context.SaveChangesAsync();
            return candidateSkill;
        }
        public async Task<CandidateSkill> UpdateCandidateSkill(int candidateId, int skillId, MarkCandidateSkill candidateSkillRequest)
        {
            var candidateSkill = await _context.CandidateSkills
                .FirstOrDefaultAsync(cs => cs.CandidateId == candidateId && cs.SkillId == skillId);

            if (candidateSkill == null)
            {
                throw new ArgumentException("Candidate skill not found.");
            }

            if (candidateSkillRequest.Experience >= 0)
            {
                candidateSkill.Experience = candidateSkillRequest.Experience;
            }

            await _context.SaveChangesAsync();
            return candidateSkill;
        }


        public async Task<bool> DeleteCandidateSkill(int id)
        {
            var CandidateSkill = await _context.CandidateSkills.FindAsync(id);
            if (CandidateSkill == null) return false;

            _context.CandidateSkills.Remove(CandidateSkill);
            await _context.SaveChangesAsync();
            return true;
        }

       public async Task<List<CandidateSkillDTO>> GetCandidateSkills(int id){
         var CandidateSkills= await (from cs in _context.CandidateSkills
                                        join c in _context.Candidates on cs.CandidateId equals c.CandidateId
                                        join s in _context.Skills on cs.SkillId equals s.SkillId
                                        where c.CandidateId==id
                                        select new CandidateSkillDTO
                                        {
                                            SkillId=s.SkillId,
                                            SkillName=s.Name,
                                            Experience=cs.Experience

                                        }).ToListAsync();
        return CandidateSkills;
       }
       
    }
}
