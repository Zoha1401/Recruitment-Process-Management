using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class InterviewFeedback
    {
        [Required]
        [Key]
        [Column("interview_feedback_id")]
        public int InterviewFeedbackId { get; set; }
        [Required]
        [Column("interviewer_interview_id")]
        public int InterviewerInterviewId { get; set; }
        public InterviewerInterview InterviewerInterview { get; set; }
        [Column("skill_id")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        [Column("rating")]
        public float Rating { get; set; }
        [Column("feedback")]
        public string? Feedback { get; set; }

       
      

    }
}