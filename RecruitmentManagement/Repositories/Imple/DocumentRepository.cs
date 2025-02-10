using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentManagement.Model;
using RecruitmentProcessManagementSystem.Data;
using RecruitmentProcessManagementSystem.Models;


namespace RecruitmentProcessManagementSystem.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly RecruitmentDbContext _context;

        public DocumentRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> GetDocumentById(int id)
        {
            return await _context.Documents.FindAsync(id);
        }

        public async Task<Document> UploadDocument(DocumentDTO document)
        {
            var documentExist=_context.Documents.FirstOrDefault(c=> c.DocumentUrl==document.DocumentUrl);
            if(documentExist!=null){
              throw new ArgumentException("Document with this email already exists");
            }

            var newDocument=new Document{
               DocumentStatusId=document.DocumentStatusId,
               DocumentUrl=document.DocumentUrl,
               ShortlistCandidateId=document.ShortlistId
            };
            _context.Documents.Add(newDocument);
            await _context.SaveChangesAsync();

            return newDocument;
        }

        public async Task<Document> UpdateDocument(int documentId, DocumentDTO Document)
        {
            var documentExist=_context.Documents.FirstOrDefault(c=> c.DocumentId==documentId);
            if(documentExist==null){
              throw new ArgumentException("Document with this id does not exist");
            }
           
            if(Document.DocumentStatusId>=0){
                documentExist.DocumentStatusId=Document.DocumentStatusId;
            }
            if(Document.DocumentUrl!=null){
                documentExist.DocumentUrl=Document.DocumentUrl;
            }
            _context.Documents.Update(documentExist);
            await _context.SaveChangesAsync();
            return documentExist;
        }

        public async Task<bool> DeleteDocument(int id)
        {
            var Document = await _context.Documents.FindAsync(id);
            if (Document == null) return false;

            _context.Documents.Remove(Document);
            await _context.SaveChangesAsync();
            return true;
        }
      
    }
}
