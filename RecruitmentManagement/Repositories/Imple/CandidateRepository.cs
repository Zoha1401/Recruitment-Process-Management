using System.Security.Cryptography;
using System.Text;
using ExcelDataReader;
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

        // public async Task<Candidate> AddCandidate(Candidate candidate)
        // {
        //     var candidateExist=_context.Candidates.FirstOrDefault(c=> c.Email==candidate.Email);
        //     if(candidateExist!=null){
        //       throw new ArgumentException("Candidate with this email already exists");
        //     }
        //     _context.Candidates.Add(candidate);
        //     await _context.SaveChangesAsync();

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
        //     return candidate;
        // }

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

        public async Task<IEnumerable<Candidate>> BulkUpload(IFormFile file){

            var candidates = new List<Candidate>();
            var users = new List<User>();
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Candidate");
            if(role==null){
                throw new Exception("role not found");
            }

            using (var stream = file.OpenReadStream())
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var dataTable = result.Tables[0];

                    for (int i = 1; i < dataTable.Rows.Count; i++) // Skip header row
                    {
                        var row = dataTable.Rows[i];
                        var firstName= row[0].ToString();
                        var last_name=row[1].ToString();
                        var email = row[2].ToString();
                        var birth_date=row[3];
                        var phone=row[4].ToString();

                        if (await _context.Users.AnyAsync(u => u.Email == email))
                            continue; 

                        var user = new User
                        {
                            Email = email,
                            Password = ComputeSha256Hash("Default@123"),
                            FirstName=firstName,
                            LastName=last_name,
                            BirthDate= (DateOnly)birth_date,
                            Phone=phone,
                            Role = role
                        };

                        users.Add(user);
                        await _context.SaveChangesAsync();

                        var candidate = new Candidate
                        {
                            UserId = user.UserId, // Link with User
                            CollegeName = row[5].ToString(),
                            Degree = row[6].ToString(),
                            WorkExperience = float.Parse(row[7].ToString()),
                            ResumeUrl = row[8].ToString()
                        };

                        candidates.Add(candidate);
                    }
                }
            }

            if (candidates.Count > 0)
            {
                await _context.Candidates.AddRangeAsync(candidates);
                await _context.SaveChangesAsync();
            }
            await _context.Users.AddRangeAsync(users);
            return candidates;
        }
       private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
