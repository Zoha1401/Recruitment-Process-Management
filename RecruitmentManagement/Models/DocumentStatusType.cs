using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class DocumentStatusType
    {
        [Key]
        [Required]
        [Column("document_status_type_id")]
        public int Id { get; set; }
        [Column("status_name")]
        public string StatusName { get; set; }

        public ICollection<Document> Documents { get; set; }
    }

}