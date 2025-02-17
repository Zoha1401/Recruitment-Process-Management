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
        public int DocumentId { get; set; }
        [Column("document_url")]
        public string DocumentUrl { get; set; }
        [Column("shortlist_candidate_id")]
        public int ShortlistCandidateId { get; set; }

        public ShortlistCandidate ShortlistCandidate { get; set; }
        [Column("document_status_type_id")]

        public int DocumentStatusTypeId {get; set;}
         public DocumentStatusType DocumentStatusType { get; set; }
    }

}