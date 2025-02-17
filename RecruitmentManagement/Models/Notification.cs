using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int CandidateId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
