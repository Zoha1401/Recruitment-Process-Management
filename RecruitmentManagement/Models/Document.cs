using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class Document
    {
        [Key]
        [Required]
        [Column("document_id")]
        public int Id { get; set; }
        [Column("document_url")]
        public string DocumentUrl { get; set; }
        [Column("shortlist_id")]
        public int ShortlistId { get; set; }

        public ShortlistCandidate ShortlistCandidate { get; set; }
        [Column("document_status_id")]
        public int DocumentStatusId{get; set;}
        public DocumentStatus DocumentStatus { get; set; }
    }

}