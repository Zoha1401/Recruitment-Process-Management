using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class CandidateSkill
    {
        // [Required]
        // [Key]
        // public int Id {get; set;}
        [Required]
        [Column("candidate_id")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public float Experience { get; set; }
        [Required]
        [Column("skill_id")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}