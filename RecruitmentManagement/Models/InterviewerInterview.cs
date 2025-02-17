using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{
    public class InterviewerInterview
    {
        [Required]
        [Key]
        [Column("interviewer_interview_id")]
        public int InterviewerInterviewId { get; set; }
        [Column("interview_id")]
        public int? InterviewId { get; set; }
        public Interview Interview { get; set; }
        [Column("interviewer_id")]
        public int? InterviewerId { get; set; }
        public User Interviewer { get; set; }

        public ICollection<InterviewFeedback> InterviewFeedbacks{get; set;}


       
        
    }
}