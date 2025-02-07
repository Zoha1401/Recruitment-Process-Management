using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class CandidateStatusType
    {
        [Required]
        [Key]
        [Column("candiate_status_type_id")]
        public int CandidateStatusTypeId { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<CandidateStatus>? CandidateStatuses { get; set; }
    }

}