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

        public async Task<IEnumerable<UserRequest>> GetCandidates()
        {
            var candidates=await (from u in _context.Users join c in _context.Candidates on u.UserId
            equals c.UserId 
            select new UserRequest{
                FirstName=u.FirstName,
                LastName=u.LastName,
                CollegeName=c.CollegeName,
                ResumeUrl=c.ResumeUrl,
                Email=u.Email

            }).ToListAsync();
            return candidates;
        }


        public async Task<Candidate> GetCandidateById(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task<Candidate> AddCandidate(CandidateDTO candidate)
        {
            var userExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == candidate.Email);

            if (userExist != null)
            {
                throw new ArgumentException("Candidate with this email already exists");
            }
            // Create a new User entry
            var user = new User
            {
                FirstName=candidate.FirstName,
                LastName=candidate.LastName,
                Phone=candidate.Phone,
                BirthDate=candidate.BirthDate,
                Email = candidate.Email,
                Password = "Default@123", // Hash the password before storing
                RoleId = 5
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Now create Candidate linked with UserId
            var newCandidate = new Candidate
            {
                UserId = user.UserId, // Assign UserId from the newly created User
                CollegeName = candidate.CollegeName,
                Degree = candidate.Degree,
                WorkExperience = candidate.WorkExperience,
                ResumeUrl = candidate.ResumeUrl
            };

            _context.Candidates.Add(newCandidate);
            await _context.SaveChangesAsync();

            return newCandidate;

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

        public async Task<IEnumerable<Candidate>> BulkUpload(IFormFile file)
        {

            var candidates = new List<Candidate>();
            var users = new List<User>();
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Candidate");
            if (role == null)
            {
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
                        var firstName = row[0].ToString();
                        var last_name = row[1].ToString();
                        var email = row[2].ToString();
                        var birth_date = row[3];
                        var phone = row[4].ToString();

                        if (await _context.Users.AnyAsync(u => u.Email == email))
                            continue;

                        var user = new User
                        {
                            Email = email,
                            Password = ComputeSha256Hash("Default@123"),
                            FirstName = firstName,
                            LastName = last_name,
                            BirthDate = (DateOnly)birth_date,
                            Phone = phone,
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

        public async Task<Candidate> GetCandidateFromUserId(int userId)
        {
            var candidate=await _context.Candidates.FirstOrDefaultAsync(u=> u.UserId==userId);
            if(candidate==null){
                throw new Exception("Candidate with this ID is not found");
            }
            return candidate;
        }

        public async Task<PositionCandidate> ApplyToPosition(int candidateId, int positionId)
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
                StatusId = 6,
                UpdatedAt = DateTime.Now,
            };

            await _context.CandidateStatuses.AddAsync(candidateStatus);
            await _context.SaveChangesAsync();

            return positionCandidate;
        }
    }
}
