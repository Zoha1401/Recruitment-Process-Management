using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class CandidateStatusRepository : ICandidateStatusRepository
    {
        private readonly RecruitmentDbContext _context;

        public CandidateStatusRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateStatus>> GetAllCandidateStatuss()
        {
            return await _context.CandidateStatuses.ToListAsync();
        }

        public async Task<CandidateStatus> GetCandidateStatusById(int id)
        {
            return await _context.CandidateStatuses.FindAsync(id);
        }

        public async Task<CandidateStatus> AddCandidateStatus(CandidateStatus CandidateStatus)
        {
            _context.CandidateStatuses.Add(CandidateStatus);
            await _context.SaveChangesAsync();
            return CandidateStatus;
        }

        public async Task<CandidateStatus> UpdateCandidateStatus(int candidate_status_id, CandidateStatusDTO candidateStatusDTO)
        {
            var candidateStatus = await _context.CandidateStatuses.FindAsync(candidate_status_id);

            if (candidateStatus == null)
            {
                throw new ArgumentException("Candidate status not found.");
            }

           
            if (candidateStatusDTO.StatusId > 0)
            {
                candidateStatus.StatusId = candidateStatusDTO.StatusId;
            }

            candidateStatus.UpdatedAt = DateTime.UtcNow; 

            if (candidateStatusDTO.UpdatedBy.HasValue)
            {
                candidateStatus.UpdatedBy = candidateStatusDTO.UpdatedBy.Value;
            }

            if (!string.IsNullOrEmpty(candidateStatusDTO.Comments))
            {
                candidateStatus.Comments = candidateStatusDTO.Comments;
            }

            _context.CandidateStatuses.Update(candidateStatus);
            await _context.SaveChangesAsync();

            return candidateStatus;

        }

        public async Task<bool> DeleteCandidateStatus(int id)
        {
            var CandidateStatus = await _context.CandidateStatuses.FindAsync(id);
            if (CandidateStatus == null) return false;

            _context.CandidateStatuses.Remove(CandidateStatus);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CandidateStatusType>> GetCandidateStatusTypes()
        {
            return await _context.CandidateStatusTypes.ToListAsync();
        }

        public async Task<CandidateStatus> GetCandidateStatusFromIds(int candidateId, int positionId)
        {
            var CandidateStatus= await (from cs in _context.CandidateStatuses
                                        where cs.CandidateId==candidateId
                                        where cs.PositionId==positionId
                                        select new CandidateStatus
                                        {
                                           CandidateStatusId=cs.CandidateStatusId,
                                           StatusId=cs.StatusId,
                                           Comments=cs.Comments,
                                           CandidateId=cs.CandidateId,
                                           PositionId=cs.PositionId
                                           
                                        }).FirstOrDefaultAsync();
            
            if(CandidateStatus==null){
                throw new Exception("There is no status for this candidate");
            }
            return CandidateStatus;
        }
    }
}
