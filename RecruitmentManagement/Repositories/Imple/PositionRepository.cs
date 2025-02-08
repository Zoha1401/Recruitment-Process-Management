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

       public async Task<Position> AddPosition([FromBody] AddPositionRequest positionRequest)
{
    var newPosition = new Position
    {
        Name = positionRequest.Name,
        NoOfInterviews = positionRequest.NoOfInterviews,
        Description = positionRequest.Description,
        PositionStatusTypeId = positionRequest.StatusId,
        MinExp = positionRequest.MinExp,
        MaxExp = positionRequest.MaxExp,
        CreatedAt=positionRequest.CreatedAt,
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


        public async Task<Position> UpdatePosition(Position Position)
        {
            _context.Positions.Update(Position);
            await _context.SaveChangesAsync();
            return Position;
        }

        public async Task<bool> DeletePosition(int id)
        {
            var Position = await _context.Positions.FindAsync(id);
            if (Position == null) return false;

            _context.Positions.Remove(Position);
            await _context.SaveChangesAsync();
            return true;
        }

    

    public async Task<Position> DefineInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions){
        var Position= _context.Positions.Find(positionId);
        if(Position==null){
            throw new ArgumentException("No such position is found for this Id");
        }
        if(interviewForPositions!=null){
        foreach (var interviewForPosition in interviewForPositions)
        {
            var InterviewType=_context.InterviewTypes.Find(interviewForPosition.TypeId);
            if(InterviewType==null){
                throw new ArgumentException ("No such interview type found");
            }
            var newPositionInterview=new PositionInterview{
                PositionId=positionId,
                NoOfInterviews=interviewForPosition.NoOfInterviews,
                InterviewTypeId=interviewForPosition.TypeId
            };
            _context.PositionInterviews.Add(newPositionInterview);

        }
        }
        await _context.SaveChangesAsync();

        return Position;
    }

    public async Task<Position> AssignReviewer(int positionId, int reviewerId){
        var reviewer= _context.Users.Find(reviewerId) ?? throw new ArgumentException("Reviewer is not found by this ID");
        var Role=_context.Roles.Find(reviewer.RoleId);
        if(Role==null){
            throw new ArgumentException("No role is assigned to user");
        }
        var roleName=Role.RoleName;
           if(roleName!="Reviewer"){
                throw new ArgumentException("The given user is not an reviewer");
            }
        var position =_context.Positions.Find(positionId) ?? throw new ArgumentException("Position not found with this ID");
        if(position.ReviewerId!=null){
            throw new ArgumentException("Reviewer for this position has already been assigned");
        }
        position.ReviewerId=reviewerId;
        position.Reviewer=reviewer;

        _context.Positions.Update(position);
        await _context.SaveChangesAsync();

        return position;
       
    }

    public async Task<Position> ChangeStatus(int positionId, PositionStatusChange positionStatusChange){
          var position =_context.Positions.Find(positionId) ?? throw new ArgumentException("Position not found with this ID");

          position.PositionStatusTypeId=positionStatusChange.StatusId;
          if(positionStatusChange.ReasonForClosure!=null){
            position.ReasonForClosure=positionStatusChange.ReasonForClosure;
          }

        _context.Positions.Update(position);
        await _context.SaveChangesAsync();

          return position;
    }

        public Task<PositionReport> FetchPositionReport(int positionId)
        {
            throw new NotImplementedException();
        }

        // public async Task<PositionReport> FetchPositionReport(int positionId){
        //     var position=await _context.Positions.FindAsync(positionId);
        //     if(position==null){
        //         throw new Exception("Position not found");
        //     }
        //     var positionCandidates = _context.PositionCandidates.ToListAsync();

        //     var query1= from c in positionCandidates
        //                 where c.PositionId equals positionId;

        // }


    }
}