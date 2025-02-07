using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{
    public class InterviewerInterview
    {
        [Required]
        [Key]
        public int InterviewerInterviewId { get; set; }
        public int? InterviewId { get; set; }
        public Interview Interview { get; set; }
        public int? InterviewerId { get; set; }
        public User Interviewer { get; set; }

        public ICollection<InterviewFeedback> InterviewFeedbacks{get; set;}


       
        
    }
}