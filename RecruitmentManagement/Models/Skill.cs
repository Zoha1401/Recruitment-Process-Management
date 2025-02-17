using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{

    public class Skill
    {

        [Required]
        [Key]
        [Column("skill_id")]
        public int SkillId { get; set; }
        [Required]
        [Column("skill_name")]
        public String Name { get; set; }


    
        public ICollection<CandidateSkill>? CandidateSkills { get; set; }
        public ICollection<InterviewFeedback>? InterviewFeedbacks { get; set; }
        public ICollection<PositionSkill>? PositionSkills { get; set; }


        public Skill(String Name)
        {
            Name = Name;
        }

        public Skill()
        {
            Name = String.Empty;
        }



    }
}

