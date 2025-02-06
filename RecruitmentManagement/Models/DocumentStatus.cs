using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class DocumentStatus
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }
        public virtual DocumentStatusType Status { get; set; }
    }

}