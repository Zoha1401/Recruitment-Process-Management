using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{

    public class PositionCandidate
    {
        [Required]
        [Key]
        [Column("position_candidate_id")]
        public int Id { get; set; }
        [Column("position_id")]
        public int PositionId { get; set; }
        public  Position Position { get; set; }

        [Column("candidate_id")]
        public int CandidateId { get; set; }
        public  Candidate Candidate { get; set; }

        [Column("comments")]
        public bool IsShortlisted { get; set; }

        [Column("application_date")]
        public DateTime ApplicationDate;

              

        public virtual ICollection<CandidateStatus>? CandidateStatuses { get; set; }
        public virtual ICollection<Interview>? Interviews { get; set; }
        public virtual ICollection<InterviewFeedback>? InterviewFeedbacks { get; set; }


    }
}