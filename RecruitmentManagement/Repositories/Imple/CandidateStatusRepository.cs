using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class CandidateStatusRepository : ICandidateStatusRepository
    {
        private readonly RecruitmentDbContext _context;

        public CandidateStatusRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuss()
        {
            return await _context.CandidateStatuses.ToListAsync();
        }

        public async Task<CandidateStatus> GetCandidateStatusById(int id)
        {
            return await _context.CandidateStatuses.FindAsync(id);
        }

        public async Task<CandidateStatus> AddCandidateStatus(CandidateStatus CandidateStatus)
        {
            _context.CandidateStatuses.Add(CandidateStatus);
            await _context.SaveChangesAsync();
            return CandidateStatus;
        }

        public async Task<CandidateStatus> UpdateCandidateStatus(CandidateStatus CandidateStatus)
        {
            _context.CandidateStatuses.Update(CandidateStatus);
            await _context.SaveChangesAsync();
            return CandidateStatus;
        }

        public async Task<bool> DeleteCandidateStatus(int id)
        {
            var CandidateStatus = await _context.CandidateStatuses.FindAsync(id);
            if (CandidateStatus == null) return false;

            _context.CandidateStatuses.Remove(CandidateStatus);
            await _context.SaveChangesAsync();
            return true;
        }
      
    }
}
