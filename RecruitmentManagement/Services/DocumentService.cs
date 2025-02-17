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
        public async Task<IEnumerable<DocumentDTO>> SaveDocuments(int shortlistId, IEnumerable<DocumentDTO> documentDTOs){
           return await _repository.SaveDocuments(shortlistId, documentDTOs);
        }
        // } 
        // public async Task<Document> UpdateDocument(int id, DocumentDTO Document) {
        //     return await _repository.UpdateDocument(id, Document);
        // } 
    
        public async Task<bool> DeleteDocument(int id) {
            return await _repository.DeleteDocument(id);
        } 
    }
}