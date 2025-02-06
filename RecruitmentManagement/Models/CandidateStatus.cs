using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

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

        // public virtual User UpdatedByUser { get; set; }
        public int PositionCandidateId { get; set; }
        public virtual PositionCandidate PositionCandidate { get; set; }
        public virtual CandidateStatusType Status { get; set; }

    }
}
