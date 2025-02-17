using RecruitmentManagement.Model;

public class PositionRequest
        {
        
        public int PositionId {get; set;}
        public String Name { get; set; }
      
        public int NoOfInterviews { get; set; }
        public string Description {get; set;}

        public int MinExp { get; set; }
        public int MaxExp { get; set; }

        public DateTime CreatedAt {get; set;}

        public DateTime? UpdatedAt{get; set;}
      
        public string? ReasonForClosure { get; set; }
      
        public int StatusId {get; set;}
        public string? StatusName {get; set;}
        public int? ReviewerId {get; set;}

        public ICollection<SkillRequest>? SkillRequests {get; set;}
        }