using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class DocumentStatusType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<DocumentStatus> DocumentStatuses { get; set; }
    }

}