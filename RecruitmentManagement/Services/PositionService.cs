using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class PositionService
    {
        private readonly IPositionRepository _repository;

        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Position>> GetAllPositions() {
            return await _repository.GetAllPositions();
        } 
        public async Task<Position> GetPositionById(int id) {
            return await _repository.GetPositionById(id);
        }
        public async Task<Position> AddPosition(AddPositionRequest Position){
           return await _repository.AddPosition(Position);
        } 
        public async Task<Position> UpdatePosition(Position Position) {
            return await _repository.UpdatePosition(Position);
        } 
    
        public async Task<bool> DeletePosition(int id) {
            return await _repository.DeletePosition(id);
        } 
    }
}