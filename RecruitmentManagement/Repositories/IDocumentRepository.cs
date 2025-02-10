using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocumentById(int id);
        Task<Document> UploadDocument(DocumentDTO Document);
        Task<Document> UpdateDocument(int document_id, DocumentDTO Document);
        Task<bool> DeleteDocument(int id);
        
    }
}