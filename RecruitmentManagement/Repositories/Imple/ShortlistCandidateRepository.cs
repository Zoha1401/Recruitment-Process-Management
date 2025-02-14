using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class ShortlistCandidateRepository : IShortlistCandidateRepository
    {
        private readonly RecruitmentDbContext _context;

        public ShortlistCandidateRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShortlistCandidate>> GetAllShortlistCandidates()
        {
            return await _context.ShortlistCandidates.ToListAsync();
        }

        public async Task<ShortlistCandidate> GetShortlistCandidateById(int id)
        {
            return await _context.ShortlistCandidates.FindAsync(id);
        }

        public async Task<ShortlistCandidate> AddShortlistCandidate(ShortlistCandidateDTO candidate)
        {
            var candidateExist=_context.ShortlistCandidates.FirstOrDefault(c=> c.CandidateId==candidate.CandidateId);
            if(candidateExist!=null){
              throw new ArgumentException("ShortlistCandidate with this ID already exists, this candidate is already assigned a position");
            }

            var newCandidate=new ShortlistCandidate{
                PositionId=candidate.PositionId,
                CandidateId=candidate.CandidateId,
                JoiningDate=candidate.JoiningDate
            };
            _context.ShortlistCandidates.Add(newCandidate);
            await _context.SaveChangesAsync();
            return newCandidate;
        }

        public async Task<ShortlistCandidate> UpdateShortlistCandidate(int shortlist_candidate_id, ShortlistCandidateDTO ShortlistCandidate)
        {
             var candidateExist=_context.ShortlistCandidates.FirstOrDefault(c=> c.CandidateId==shortlist_candidate_id);
            if(candidateExist==null){
              throw new ArgumentException("No shortlisted candidate with this ID found");
            }
            if(ShortlistCandidate.PositionId>=0){
            candidateExist.PositionId=ShortlistCandidate.PositionId;
            }
            if(ShortlistCandidate.CandidateId>=0){
            candidateExist.CandidateId=ShortlistCandidate.CandidateId;
            }
            if(ShortlistCandidate.JoiningDate!=null){
            candidateExist.JoiningDate=ShortlistCandidate.JoiningDate;
            }

            _context.ShortlistCandidates.Update(candidateExist);
            await _context.SaveChangesAsync();
            return candidateExist;
        }

        public async Task<bool> DeleteShortlistCandidate(int id)
        {
            var ShortlistCandidate = await _context.ShortlistCandidates.FindAsync(id);
            if (ShortlistCandidate == null) return false;

            _context.ShortlistCandidates.Remove(ShortlistCandidate);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ShortlistedCandidateDTO>> GetAllShortlistedCandidates(){
            var ShortlistedCandidates=await (from u in _context.Users join c in _context.Candidates
                                              on u.UserId equals c.UserId join sc in _context.ShortlistCandidates 
                                              on c.CandidateId equals sc.CandidateId join p in _context.Positions on
                                              sc.PositionId equals p.PositionId
                                              select new ShortlistedCandidateDTO{
                                                Email=u.Email,
                                                FirstName=u.FirstName,
                                                LastName=u.LastName,
                                                PositionName=p.Name,
                                                ShortlistCandidateId=sc.ShortlistCandidateId
                    
                                              }).ToListAsync();
            return ShortlistedCandidates;
        }

        public async Task<bool> IsShortlisted(int candidateId){
            var findCandidate=await _context.ShortlistCandidates.FirstOrDefaultAsync(sc=>sc.CandidateId==candidateId);
            if(findCandidate!=null){
                return true;
            }
            return false;
        }
      
    } 
}
