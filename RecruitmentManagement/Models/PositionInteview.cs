using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{

    public class PositionInterview
    {

        [Required]
        [Key]
        [Column("position_interview_id")]
        public int PositionInterviewId { get; set; }
        
        [Required]
        [Column("position_id")]
        public int PositionId {get; set;}

        public Position position {get; set;}
        [Column("no_of_inteviews")]
        public int NoOfInterviews {get; set;}
        
        [Required]
        [Column("interview_type_id")]
        public int InterviewTypeId {get; set;}

        public InterviewType interviewType;
       


       



    }
}

