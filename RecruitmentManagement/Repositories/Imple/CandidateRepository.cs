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

        public async Task<Candidate> AddCandidate(Candidate candidate)
        {
            var candidateExist=_context.Candidates.FirstOrDefault(c=> c.Email==candidate.Email);
            if(candidateExist!=null){
              throw new ArgumentException("Candidate with this email already exists");
            }
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

    //         var userExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == candidate.Email);
    
    // if (userExist != null)
    // {
    //     throw new ArgumentException("Candidate with this email already exists");
    // }

    // // Create a new User entry
    // var user = new User
    // {
    //     Email = candidate.Email,
    //     Password = HashPassword(candidate.Password), // Hash the password before storing
    //     Role = "Candidate"
    // };

    // _context.Users.Add(user);
    // await _context.SaveChangesAsync();

    // // Now create Candidate linked with UserId
    // var newCandidate = new Candidate
    // {
    //     UserId = user.UserId, // Assign UserId from the newly created User
    //     Name = candidate.Name,
    //     CollegeName = candidate.CollegeName,
    //     Degree = candidate.Degree,
    //     WorkExperience = candidate.WorkExperience,
    //     ResumeUrl = candidate.ResumeUrl
    // };

    // _context.Candidates.Add(newCandidate);
    // await _context.SaveChangesAsync();

    // return newCandidate;
            return candidate;
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
