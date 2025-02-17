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
        public async Task<Position> AddPosition(PositionRequest Position){
           return await _repository.AddPosition(Position);
        } 
        public async Task<Position> UpdatePosition(int positionId , PositionRequest Position) {
            return await _repository.UpdatePosition(positionId, Position);
        } 
    
        public async Task<bool> DeletePosition(int id) {
            return await _repository.DeletePosition(id);
        } 

        public async Task<Position> DefineInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions){
            return await _repository.DefineInterviewRounds(positionId, interviewForPositions);
        }
        public async Task<Position> UpdateInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions){
            return await _repository.UpdateInterviewRounds(positionId, interviewForPositions);
         }
        public async Task<Position> AssignReviewer(int positionId, int reviewerId)
        {
            return await _repository.AssignReviewer(positionId, reviewerId);
        }

        public async Task<Position> ChangeStatus(int positionId, PositionStatusChange positionStatusChange){
            return await _repository.ChangeStatus(positionId, positionStatusChange);
        }

        public async Task<IEnumerable<Position>> GetPositionsForReviewer(int reviewerId){
            return await _repository.GetPositionsForReviewer(reviewerId);
        }

        // public async Task<List<PositionReport>> FetchPositionReport(int positionId)
        // {
        //     return await _repository.FetchPositionReport(positionId);
        // }

        // public async Task<List<CollegewiseReport>> FetchCollegewiseReport(int positionId)
        // {
        //     return await _repository.FetchCollegewiseReport(positionId);
        // }

         public async Task<IEnumerable<RecruitmentManagement.Model.PositionStatusType>> GetAllPositionStatusTypes()
        {
            return await _repository.GetAllPositionStatusTypes();
        }

         public async Task<Position> AddPositionSkills(int positionId, List<SkillRequest> skillRequests){
            return await _repository.AddPositionSkills(positionId, skillRequests);
         }

        public async Task<User> GetAssignedReviewer(int positionId){
            return await _repository.GetAssignedReviewer(positionId);
        }

          public async  Task<RecruitmentManagement.Model.PositionStatusType> GetPositionStatusTypeById (int statusId){
            return await _repository.GetPositionStatusTypeById(statusId);
          }
    }
}