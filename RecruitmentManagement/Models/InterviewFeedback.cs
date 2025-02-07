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
        [Required]
        public int InterviewerInterviewId { get; set; }
        public InterviewerInterview InterviewerInterview { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public float Rating { get; set; }
        public string Feedback { get; set; }

       
      

    }
}