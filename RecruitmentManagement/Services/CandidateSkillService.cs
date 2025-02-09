using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Repositories;

public class CandidateSkillService
{
    private readonly RecruitmentDbContext _context;
    private readonly ICandidateSkillRepository _repository;

    public CandidateSkillService(RecruitmentDbContext context, ICandidateSkillRepository repository)
    {
        _context = context;
         _repository = repository;
    }

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

      public async Task<CandidateSkill> AddCandidateSkill(int candidateId, int skillId, MarkCandidateSkill CandidateSkill)
        {
            return await _repository.AddCandidateSkill(candidateId, skillId, CandidateSkill);
        }

        public async Task<CandidateSkill> UpdateCandidateSkill(int candidateId, int skillId, MarkCandidateSkill CandidateSkill)
        {
            return await _repository.UpdateCandidateSkill(candidateId, skillId, CandidateSkill);
        }

         public async Task<bool> DeleteCandidateSkill(int id) {
            return await _repository.DeleteCandidateSkill(id);
        } 
 }