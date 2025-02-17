using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Migrations;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly RecruitmentDbContext _context;

        public PositionRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionById(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<Position> AddPositionSkills(int positionId, [FromBody] List<SkillRequest> skillRequests){
            var position=await _context.Positions.FirstOrDefaultAsync(p=>p.PositionId==positionId);
            if(position==null)
            {
                throw new Exception("Position is not found");
            }
             if (skillRequests != null)
            {
                foreach (var skillRequest in skillRequests)
                {
                    var skill = _context.Skills.Find(skillRequest.SkillId);
                    if (skill != null)
                    {
                        var newPositionSkill = new PositionSkill
                        {
                            Skill = skill,
                            Position = position, // Establish relationship
                            Required = skillRequest.Required
                        };
                        position.PositionSkills.Add(newPositionSkill);
                    }
                    else
                    {
                        Console.WriteLine($"Skill with ID {skillRequest.SkillId} not found.");
                    }
                }
            }
             await _context.SaveChangesAsync();

            return position;


        } 
        public async Task<Position> AddPosition([FromBody] PositionRequest positionRequest)
        {
            var newPosition = new Position
            {
                Name = positionRequest.Name,
                NoOfInterviews = positionRequest.NoOfInterviews,
                Description = positionRequest.Description,
                PositionStatusTypeId = 1,
                MinExp = positionRequest.MinExp,
                MaxExp = positionRequest.MaxExp,
                CreatedAt = DateTime.Now
            };

            // Iterate over the incoming SkillRequests and add PositionSkill objects
            if (positionRequest.SkillRequests != null)
            {
                foreach (var skillRequest in positionRequest.SkillRequests)
                {
                    var skill = _context.Skills.Find(skillRequest.SkillId);
                    if (skill != null)
                    {
                        var newPositionSkill = new PositionSkill
                        {
                            Skill = skill,
                            Position = newPosition, // Establish relationship
                            Required = skillRequest.Required
                        };
                        newPosition.PositionSkills.Add(newPositionSkill);
                    }
                    else
                    {
                        Console.WriteLine($"Skill with ID {skillRequest.SkillId} not found.");
                    }
                }
            }

            _context.Positions.Add(newPosition);
            await _context.SaveChangesAsync();

            return newPosition;
        }


        public async Task<Position> UpdatePosition(int positionId, PositionRequest positionRequest)
        {
            var position = await _context.Positions
                .Include(p => p.PositionSkills)
                .FirstOrDefaultAsync(p => p.PositionId == positionId);

            if (position == null)
            {
                throw new ArgumentException("Position not found.");
            }


            if (!string.IsNullOrEmpty(positionRequest.Description))
                position.Description = positionRequest.Description;
            if (positionRequest.Name != null)
                position.Name = positionRequest.Name;

            if (positionRequest.MinExp >= 0)
                position.MinExp = positionRequest.MinExp;

            if (positionRequest.MaxExp >= 0)
                position.MaxExp = positionRequest.MaxExp;

            if (positionRequest.NoOfInterviews >= 0)
                position.NoOfInterviews = positionRequest.NoOfInterviews;

            if (!string.IsNullOrEmpty(positionRequest.ReasonForClosure))
                position.ReasonForClosure = positionRequest.ReasonForClosure;

            if (positionRequest.StatusId >= 0)
                position.PositionStatusTypeId = positionRequest.StatusId;

            if (positionRequest.ReviewerId >= 0)
                position.ReviewerId = positionRequest.ReviewerId;

            position.UpdatedAt = DateTime.UtcNow;


            if (positionRequest.SkillRequests != null)
            {

                var existingSkills = position.PositionSkills.ToDictionary(ps => ps.SkillId);

                foreach (var skillRequest in positionRequest.SkillRequests)
                {
                    var skill = await _context.Skills.FindAsync(skillRequest.SkillId);
                    if (skill == null)
                    {

                        Console.WriteLine($"Skill with ID {skillRequest.SkillId} not found.");
                        continue;
                    }

                    if (existingSkills.TryGetValue(skill.SkillId, out var existingSkill))
                    {

                        if (existingSkill.Required != skillRequest.Required)
                        {
                            existingSkill.Required = skillRequest.Required;
                        }
                    }
                    else
                    {

                        position.PositionSkills.Add(new PositionSkill
                        {
                            PositionId = positionId,
                            SkillId = skill.SkillId,
                            Required = skillRequest.Required
                        });
                    }
                }


                var newSkillIds = positionRequest.SkillRequests.Select(sr => sr.SkillId).ToHashSet();
                var skillsToRemove = position.PositionSkills.Where(ps => !newSkillIds.Contains(ps.SkillId)).ToList();


                _context.PositionSkills.RemoveRange(skillsToRemove);
            }

            _context.Positions.Update(position);
            await _context.SaveChangesAsync();

            return position;
        }



        public async Task<bool> DeletePosition(int id)
        {
            var Position = await _context.Positions.FindAsync(id);
            if (Position == null) return false;

            _context.Positions.Remove(Position);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Position> DefineInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions)
        {
            var Position = _context.Positions.Find(positionId);
            if (Position == null)
            {
                throw new ArgumentException("No such position is found for this Id");
            }
            if (interviewForPositions != null)
            {
                foreach (var interviewForPosition in interviewForPositions)
                {
                    var InterviewType = _context.InterviewTypes.Find(interviewForPosition.TypeId);
                    if (InterviewType == null)
                    {
                        throw new ArgumentException("No such interview type found");
                    }
                    var newPositionInterview = new PositionInterview
                    {
                        PositionId = positionId,
                        NoOfInterviews = interviewForPosition.NoOfInterviews,
                        InterviewTypeId = interviewForPosition.TypeId
                    };
                    _context.PositionInterviews.Add(newPositionInterview);

                }
            }
            await _context.SaveChangesAsync();

            return Position;
        }

        public async Task<Position> UpdateInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions)
        {
            var position = await _context.Positions.FindAsync(positionId);
            if (position == null)
            {
                throw new ArgumentException("No such position is found for this Id");
            }

            if (interviewForPositions == null || !interviewForPositions.Any())
            {
                throw new ArgumentException("Interview rounds cannot be empty.");
            }

            
            var existingInterviews = _context.PositionInterviews.Where(pi => pi.PositionId == positionId).ToList();
            foreach (var interviewForPosition in interviewForPositions)
            {
                var interviewType = await _context.InterviewTypes.FindAsync(interviewForPosition.TypeId);
                if (interviewType == null)
                {
                    throw new ArgumentException($"No interview type found for ID {interviewForPosition.TypeId}");
                }

                var existingInterview = existingInterviews.FirstOrDefault(pi => pi.InterviewTypeId == interviewForPosition.TypeId);
                if (existingInterview != null)
                {
                    existingInterview.NoOfInterviews = interviewForPosition.NoOfInterviews;
                }
                else
                {
                    var newPositionInterview = new PositionInterview
                    {
                        PositionId = positionId,
                        NoOfInterviews = interviewForPosition.NoOfInterviews,
                        InterviewTypeId = interviewForPosition.TypeId
                    };
                    _context.PositionInterviews.Add(newPositionInterview);
                }
            }
            var newInterviewTypeIds = interviewForPositions.Select(i => i.TypeId).ToList();
            var interviewsToRemove = existingInterviews.Where(i => !newInterviewTypeIds.Contains(i.InterviewTypeId)).ToList();
            _context.PositionInterviews.RemoveRange(interviewsToRemove);

            await _context.SaveChangesAsync();

            return position;
        }


        public async Task<Position> AssignReviewer(int positionId, int reviewerId)
        {
            var reviewer = _context.Users.Find(reviewerId) ?? throw new ArgumentException("Reviewer is not found by this ID");
            var Role = _context.Roles.Find(reviewer.RoleId);
            if (Role == null)
            {
                throw new ArgumentException("No role is assigned to user");
            }
            var roleName = Role.RoleName;
            if (roleName != "Reviewer")
            {
                throw new ArgumentException("The given user is not an reviewer");
            }
            var position = _context.Positions.Find(positionId) ?? throw new ArgumentException("Position not found with this ID");
            if (position.ReviewerId != null)
            {
                throw new ArgumentException("Reviewer for this position has already been assigned");
            }
            position.ReviewerId = reviewerId;
            position.Reviewer = reviewer;

            _context.Positions.Update(position);
            await _context.SaveChangesAsync();

            return position;

        }

        public async Task<Position> ChangeStatus(int positionId, PositionStatusChange positionStatusChange)
        {
            var position = _context.Positions.Find(positionId) ?? throw new ArgumentException("Position not found with this ID");

            position.PositionStatusTypeId = positionStatusChange.StatusId;
            if (positionStatusChange.ReasonForClosure != null)
            {
                position.ReasonForClosure = positionStatusChange.ReasonForClosure;
            }

            _context.Positions.Update(position);
            await _context.SaveChangesAsync();

            return position;
        }

        public async Task<IEnumerable<Position>> GetPositionsForReviewer(int reviewerId)
        {
            var positions=await _context.Positions.ToListAsync();
            var reviewerPositions=positions.FindAll(rp=> rp.ReviewerId==reviewerId);

            if(reviewerPositions==null){
                throw new Exception("There are no positions to review");
            }

            return reviewerPositions;
        }

         public async Task<IEnumerable<RecruitmentManagement.Model.PositionStatusType>> GetAllPositionStatusTypes()
        {
            return await _context.PositionStatusTypes.ToListAsync();
        }

        public async Task<User> GetAssignedReviewer(int positionId){
            var position=await _context.Positions.FirstOrDefaultAsync(p=>p.PositionId==positionId);
            if(position==null){
                throw new Exception("Position not found for this ID");
            }
            var reviewer=await _context.Users.FirstOrDefaultAsync(u=> u.UserId==position.ReviewerId);
            if(reviewer==null){
                throw new Exception("Reviewer is not found");
            }
            return reviewer;
        }

        public async  Task<RecruitmentManagement.Model.PositionStatusType> GetPositionStatusTypeById (int statusId){
            var statusType= await _context.PositionStatusTypes.FirstOrDefaultAsync(ps=>ps.PositionStatusTypeId==statusId);
            if(statusType==null){
                throw new Exception("Status type not found");
            }
            return statusType;
        }

    }
}