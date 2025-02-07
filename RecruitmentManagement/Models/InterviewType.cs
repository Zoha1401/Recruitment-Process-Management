using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentManagement.Model
{

    public class InterviewType
    {

        [Required]
        [Key]
        [Column("interview_type_id")]
        public int InterviewTypeId { get; set; }
        [Required]
        [Column("interview_type")]
        public String Type { get; set; }
       
        public ICollection<PositionInterview> positionInterviews{get; set;}
        public ICollection<Interview>? Interviews{get; set;}

    }
}

