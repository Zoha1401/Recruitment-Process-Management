using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{
    public class CandidateStatus
    {
        [Required]
        [Key]
        [Column("candidate_status_id")]
        public int CandidateStatusId { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        public CandidateStatusType Status { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column("updated_by")]
        public int? UpdatedBy{get; set;}
        public User? User{get; set;}
        [Column("comments")]
        public string? Comments { get; set; }
        // public virtual User UpdatedByUser { get; set; }
        // [Column("position_candidate_id")]
        // public int PositionCandidateId { get; set; }
        // public PositionCandidate PositionCandidate { get; set; }

        public int PositionId{get; set;}
        public Position Position {get; set;}

        public int CandidateId {get; set;}
        public Candidate Candidate {get; set;}
        

    }
}
