using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.DTOs
{

    public class PositionCandidateDTO
    {
       
        public int? PositionId { get; set; }
        public int? CandidateId { get; set; }
        public bool? IsShortlisted { get; set; }
        public DateTime? ApplicationDate {get; set;}
        public bool? IsReviewed{get; set;}

        public String? Comments{get; set;}

    }
}