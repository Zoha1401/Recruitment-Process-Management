using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;

public class ApplicationService
{
    private readonly RecruitmentDbContext _context;

    public ApplicationService(RecruitmentDbContext context)
    {
        _context = context;
    }

    public void ApplyToPosition(int candidateId, int positionId)
    {
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
            ApplicationDate = DateTime.Now
        };

        _context.PositionCandidates.Add(positionCandidate);
        _context.SaveChanges();
    }
}