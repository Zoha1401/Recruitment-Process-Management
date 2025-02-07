using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{

    public class Interview
    {

        [Required]
        [Key]
        [Column("interview_id")]
        public int InterviewId { get; set; }
        [Required]
        [Column("interview_type_id")]
        public int InterviewTypeId { get; set; }
        public InterviewType InterviewType { get; set; }
        [Required]
        [Column("interview_date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("recruiter_id")]
        public int RecruiterId { get; set; }
        public User Recruiter { get; set; }

        [Column("position_candidate_id")]
        public int PositionCandidateId { get; set; }

        public PositionCandidate PositionCandidate { get; set; }
        [Column("round_number")]
        public int RoundNumber { get; set; }


        public ICollection<InterviewerInterview>? InterviewerInterviews { get; set; }
        public ICollection<InterviewFeedback>? InterviewFeedbacks { get; set; }



    }
}

