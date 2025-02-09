using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;

namespace RecruitmentManagement.Model
{
    public class CandidateStatusDTO
    {
       
        public int StatusId { get; set; }
        public DateTime UpdatedAt { get; set; }
      
        public int? UpdatedBy{get; set;}
        public string? Comments { get; set; }

        public int PositionId{get; set;}
       

        public int CandidateId {get; set;}
    
        

    }
}
