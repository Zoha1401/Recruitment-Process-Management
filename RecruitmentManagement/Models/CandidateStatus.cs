using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{
    public class CandidateStatus
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Comments { get; set; }

        public int UpdatedBy{get; set;}
        public User User{get; set;}

        // public virtual User UpdatedByUser { get; set; }
        public int PositionCandidateId { get; set; }
        public virtual PositionCandidate PositionCandidate { get; set; }
        public virtual CandidateStatusType Status { get; set; }

    }
}
