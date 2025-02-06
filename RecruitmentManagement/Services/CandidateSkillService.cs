using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;

public class CandidateSkillService
{
    private readonly RecruitmentDbContext _context;

    public CandidateSkillService(RecruitmentDbContext context)
    {
        _context = context;
    }

//Will Require a DTO for experience
    public void MarkSkills(int candidateId, ICollection<MarkCandidateSkill> skills)
    {
        var candidate = _context.Candidates.Find(candidateId);
       

        if (candidate == null)
        {
            throw new ArgumentException("Invalid candidate");
        }
        foreach(var skill in skills){
            var candidateSkill = new CandidateSkill
            {
             CandidateId=candidateId,
             SkillId=skill.SkillId,
             Experience=skill.Experience

        };
         _context.CandidateSkills.Add(candidateSkill);
  
        }
        
       
        _context.SaveChanges();
    }
}