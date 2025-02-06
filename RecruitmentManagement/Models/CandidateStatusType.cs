using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class CandidateStatusType
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<CandidateStatus>? CandidateStatuses { get; set; }
    }

}