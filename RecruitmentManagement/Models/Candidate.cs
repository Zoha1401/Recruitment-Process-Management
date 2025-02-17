using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{

    public class Candidate
    {

        [Required]
        [Key]
        [Column("candidate_id")]
        public int CandidateId { get; set; }
        // [Required]
        // [Column("name")]
        // public String Name { get; set; }
        // [Required]
        // [Column("email")]
        // public String Email { get; set; }
        // [Required]
        // [Column("password")]
        // public String Password { get; set; }
        [Required]
        [Column("user_id")]
        public int UserId {get; set;}
        public User User{get; set;}
        [Required]
        [Column("college_name")]
        public  String CollegeName { get; set; }
        [Required]
        [Column("degree")]
        public  String Degree { get; set; }
        [Required]
        [Column("work_experience")]
        public float WorkExperience { get; set; }
        [Column("resume_url")]
        public string ResumeUrl { get; set; }

        public virtual ICollection<CandidateSkill>? CandidateSkills { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<PositionCandidate>? PositionCandidates { get; set; }
        public virtual ICollection<ShortlistCandidate>? ShortlistCandidates { get; set; }

        public ICollection<CandidateStatus>? CandidateStatuses {get; set;}

       


       



    }
}

