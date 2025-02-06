using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly RecruitmentDbContext _context;

        public CandidateRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task<Candidate> AddCandidate(Candidate Candidate)
        {
            _context.Candidates.Add(Candidate);
            await _context.SaveChangesAsync();
            return Candidate;
        }

        public async Task<Candidate> UpdateCandidate(Candidate Candidate)
        {
            _context.Candidates.Update(Candidate);
            await _context.SaveChangesAsync();
            return Candidate;
        }

        public async Task<bool> DeleteCandidate(int id)
        {
            var Candidate = await _context.Candidates.FindAsync(id);
            if (Candidate == null) return false;

            _context.Candidates.Remove(Candidate);
            await _context.SaveChangesAsync();
            return true;
        }
      
    }
}
