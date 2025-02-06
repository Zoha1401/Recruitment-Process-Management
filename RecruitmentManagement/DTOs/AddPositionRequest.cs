using RecruitmentManagement.Model;

public class AddPositionRequest
        {
        
        public String Name { get; set; }
      
        public int NoOfInterviews { get; set; }
        public string Description {get; set;}

        public int MinExp { get; set; }
        public int MaxExp { get; set; }
      
        public string? ReasonForClosure { get; set; }
      
        public int StatusId {get; set;}

        public ICollection<SkillRequest>? SkillRequests {get; set;}
        }