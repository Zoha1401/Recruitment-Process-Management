using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class PositionSkill
    {

        // [Required]
        // [Key]
        // [Column("position_skill_id")]
        // public int Id { get; set; }
        [Column("position_id")]
        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [Column("skill_id")]
        [Required]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        
        [Required]
        [Column("Required")]
        public string Required { get; set; }
    }
}