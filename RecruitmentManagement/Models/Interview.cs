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
        public int InterviewTypeId{ get; set; }
        public InterviewType InterviewType{get; set;}
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int RecruiterId {get; set;}
        public User Recruiter {get; set;}


        public int PositionCandidateId { get; set; }

        public PositionCandidate PositionCandidate { get; set; }

        public int RoundNumber{get; set;}


        public ICollection<InterviewerInterview>? InterviewerInterviews { get; set; }
        public ICollection<InterviewFeedback>? InterviewFeedbacks { get; set; }



    }
}

