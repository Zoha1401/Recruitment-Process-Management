using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly RecruitmentDbContext _context;

        public InterviewRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Interview>> GetAllInterviews()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task<Interview> GetInterviewById(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }

        public async Task<Interview> AddInterview(Interview Interview)
        {
            _context.Interviews.Add(Interview);
            await _context.SaveChangesAsync();
            return Interview;
        }

        public async Task<Interview> UpdateInterview(Interview Interview)
        {
            _context.Interviews.Update(Interview);
            await _context.SaveChangesAsync();
            return Interview;
        }

        public async Task<bool> DeleteInterview(int id)
        {
            var Interview = await _context.Interviews.FindAsync(id);
            if (Interview == null) return false;

            _context.Interviews.Remove(Interview);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}