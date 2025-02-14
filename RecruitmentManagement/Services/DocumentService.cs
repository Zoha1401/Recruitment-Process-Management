using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Models;
using RecruitmentProcessManagementSystem.Repositories;


namespace RecruitmentProcessManagementSystem.Service
{
    public class DocumentService
    {
        private readonly IDocumentRepository _repository;

        public DocumentService(IDocumentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Document>> GetAllDocuments() {
            return await _repository.GetAllDocuments();
        } 
        public async Task<Document> GetDocumentById(int id) {
            return await _repository.GetDocumentById(id);
        }
        public async Task<Document> UploadDocument(int shortlistId, IFormFile file){
           return await _repository.UploadDocument(shortlistId, file);
        } 
        public async Task<Document> UpdateDocument(int id, DocumentDTO Document) {
            return await _repository.UpdateDocument(id, Document);
        } 
    
        public async Task<bool> DeleteDocument(int id) {
            return await _repository.DeleteDocument(id);
        } 
    }
}