using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class CandidateSkill
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public float Experience { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}