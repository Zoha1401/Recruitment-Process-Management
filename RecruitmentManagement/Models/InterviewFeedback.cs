using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class InterviewFeedback
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int InterviewInterviewerId { get; set; }
        public InterviewerInterview Interview { get; set; }
        public int SkillId { get; set; }
        public float Rating { get; set; }
        public string Feedback { get; set; }

       
        public virtual Skill Skill { get; set; }

    }
}