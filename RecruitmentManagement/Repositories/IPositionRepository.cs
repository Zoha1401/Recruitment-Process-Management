using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositions();
        Task<Position> GetPositionById(int id);
        Task<Position> AddPosition(AddPositionRequest Position);
        Task<Position> UpdatePosition(Position Position);
        Task<bool> DeletePosition(int id);
        
    }
}