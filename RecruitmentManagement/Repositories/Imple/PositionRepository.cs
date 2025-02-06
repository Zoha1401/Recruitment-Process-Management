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
        StatusId = positionRequest.StatusId,
        MinExp = positionRequest.MinExp,
        MaxExp = positionRequest.MaxExp
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

    }
}