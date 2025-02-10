using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class DocumentStatus
    {
        [Key]
        [Required]
        [Column("document_status_id")]
        public int Id { get; set; }
        [Column("document_status_type_id")]
        public int StatusId { get; set; }
        [Column("document_id")]
        public int DocumentId { get; set; }

        public Document Document { get; set; }
        public DocumentStatusType Status { get; set; }
    }

}