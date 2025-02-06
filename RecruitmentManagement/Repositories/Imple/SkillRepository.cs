using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly RecruitmentDbContext _context;

        public SkillRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill> GetSkillById(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<Skill> AddSkill(Skill Skill)
        {
            _context.Skills.Add(Skill);
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task<Skill> UpdateSkill(Skill Skill)
        {
            _context.Skills.Update(Skill);
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var Skill = await _context.Skills.FindAsync(id);
            if (Skill == null) return false;

            _context.Skills.Remove(Skill);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}