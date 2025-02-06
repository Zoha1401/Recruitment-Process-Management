using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class Document
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string DocumentUrl { get; set; }
        public int ShortlistId { get; set; }

        public virtual ShortlistCandidate ShortlistCandidate { get; set; }
        public virtual ICollection<DocumentStatus> DocumentStatuses { get; set; }
    }

}