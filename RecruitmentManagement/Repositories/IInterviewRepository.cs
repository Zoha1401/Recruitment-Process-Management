using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IInterviewRepository
    {
        Task<IEnumerable<Interview>> GetAllInterviews();
        Task<Interview> GetInterviewById(int id);
        Task<Interview> AddInterview(Interview Interview);
        Task<Interview> UpdateInterview(Interview Interview);
        Task<bool> DeleteInterview(int id);
        
    }
}