using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{

    public class Position
    {

        [Required]
        [Key]
        [Column("position_id")]
        public int PositionId { get; set; }
        [Required]
        [Column("position_name")]
        public String Name { get; set; }
        [Required]
        [Column("noOfInterviews")]
        public int NoOfInterviews { get; set; }

        [Required]
        [Column("description")]
        public string Description {get; set;}

        [Required]
        [Column("min_exp")]
        public int MinExp { get; set; }
        [Required]
        [Column("max_exp")]
        public int MaxExp { get; set; }
        [Column("closure_reason")]
        public string? ReasonForClosure { get; set; }
        [Column("status_id")]
        public int PositionStatusTypeId {get; set;}
        public PositionStatusType PositionStatusType {get; set;}
        [Column("reviewer_id")]
        public int? ReviewerId {get; set;}
        public User Reviewer {get; set;}
       

        public  ICollection<PositionCandidate>? PositionCandidates { get; set; }
        public  ICollection<PositionSkill>? PositionSkills { get; set; }



        public Position(String Name, int NoOfInterviews, int minExp, int maxExp, String desc)
        {
            this.Name = Name;
            this.NoOfInterviews = NoOfInterviews;
            this.MinExp = minExp;
            this.MaxExp = maxExp;
            this.Description=desc;
            PositionSkills = [];
            PositionCandidates=[];
        }

        public Position()
        {
            Name = String.Empty;
            NoOfInterviews = 0;
            MinExp=0;
            MaxExp=0;   
            PositionSkills = new List<PositionSkill>();
        }



    }
}

