using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Models
{
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }

        [Column("birth_date")]
        public DateOnly? BirthDate {get; set;}
        
        [Column("phone")]
        public string? Phone { get; set; }
        
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<InterviewerInterview>? InterviewerInterviews{get; set;}
        public ICollection<CandidateStatus>? CandidateStatuses{get; set;}
        public ICollection<Candidate>? Candidates{get; set;}
        
    }
}