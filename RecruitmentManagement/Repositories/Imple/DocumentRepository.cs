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

        public async Task<Document> UploadDocument(DocumentDTO document, IFormFile request)
        {
            string folderPath = Path.Combine("C:\\Users\\suratzoh\\Desktop\\Project\\RecruitmentManagement>", "uploads");
        
        // create the directory if it does not exist
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        // extract the file extension for some specific purpose - like validation
        string extension = Path.GetExtension(request.FileName);
        
        // You can add validation here to allow only specific files using the extension extracted - 
        if (!IsValidFile(extension))
        {
            throw new Exception("Please upload either pdf, jpg or png");
        }
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(request.FileName);
        
        // I am concatenating a new guid to the end of the filename so that if file with same name is uploaded twice that is handled correctly
        string fileName = $"{fileNameWithoutExtension}_{Guid.NewGuid()}{extension}";
        string filePath = Path.Combine(folderPath, fileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await request.CopyToAsync(stream);
        

         var documentExist=_context.Documents.FirstOrDefault(c=> c.DocumentUrl==document.DocumentUrl);
            if(documentExist!=null){
              throw new ArgumentException("Document with this email already exists");
            }

            var newDocument=new Document{
               DocumentStatusTypeId=document.DocumentStatusTypeId,
               DocumentUrl=$"/uploads/{fileName}",
               ShortlistCandidateId=document.ShortlistId
            };
              _context.Documents.Add(newDocument);
            await _context.SaveChangesAsync();

            return newDocument;
    }
    
    

  

        private static bool IsValidFile(string extension)
        {
            if (extension == "png" || extension == "jpg" || extension =="pdf")
            {
                return true;
            }
            return false;
        }

       


        public async Task<Document> UpdateDocument(int documentId, DocumentDTO Document)
        {
            var documentExist=_context.Documents.FirstOrDefault(c=> c.DocumentId==documentId);
            if(documentExist==null){
              throw new ArgumentException("Document with this id does not exist");
            }
           
            if(Document.DocumentStatusTypeId>=0){
                documentExist.DocumentStatusTypeId=Document.DocumentStatusTypeId;
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
