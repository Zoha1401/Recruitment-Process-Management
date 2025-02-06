using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Model
{
    public class ShortlistCandidate
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public required virtual Candidate Candidate { get; set; }
        public DateTime JoiningDate { get; set; }
       
    }
}