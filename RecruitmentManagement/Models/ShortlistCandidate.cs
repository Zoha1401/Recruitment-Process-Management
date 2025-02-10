using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class ShortlistCandidate
    {
        [Required]
        [Key]
        [Column("shortlist_candidate_id")]
        public int ShortlistCandidateId { get; set; }
        [Column("canidate_id")]
        [Required]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [Column("joining_date")]
        public DateTime? JoiningDate { get; set; }

        [Column("position_id")]
        [Required]
        public int PositionId{get; set;}
        public Position Position{get; set;}

        //URL of offer letter
       
    }
}