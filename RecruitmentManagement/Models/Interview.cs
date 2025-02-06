using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{

    public class Interview
    {

        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int TypeId{ get; set; }
        public InterviewType InterviewType{get; set;}
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int RecruiterId {get; set;}
        public User Recruiter {get; set;}


        public int PositionCandidateId { get; set; }

        public virtual required PositionCandidate PositionCandidate { get; set; }

        public ICollection<InterviewerInterview>? InterviewerInterviews { get; set; }
        public virtual ICollection<InterviewFeedback>? InterviewFeedbacks { get; set; }



    }
}

