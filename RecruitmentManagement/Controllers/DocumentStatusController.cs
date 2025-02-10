using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using ExcelDataReader;
using RecruitmentProcessManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "HRPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentStatusController : ControllerBase
    {
        private readonly RecruitmentDbContext _context;

        public DocumentStatusController(RecruitmentDbContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //     var DocumentVerifications = await _service.GetAllDocumentVerifications();
        //     if (DocumentVerifications == null)
        //     {
        //         return NotFound("There are no candidates");
        //     }
        //     return Ok(DocumentVerifications);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetById(int id)
        // {
        //     var DocumentVerification = await _service.GetDocumentVerificationById(id);
        //     if (DocumentVerification == null)
        //         return NotFound("Student not found.");
        //     return Ok(DocumentVerification);
        // }

        // [HttpPost]
        // public async Task<IActionResult> Add([FromBody] DocumentVerificationDTO DocumentVerification)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var addedDocumentVerification = await _service.UploadDocumentVerification(DocumentVerification, DocumentVerification.formFile);
        //     return CreatedAtAction(nameof(GetById), new { id = addedDocumentVerification.DocumentVerificationId }, addedDocumentVerification);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] DocumentVerificationDTO DocumentVerification)
        // {
        //     var updatedDocumentVerification = await _service.UpdateDocumentVerification(id, DocumentVerification);
        //     if (updatedDocumentVerification == null)
        //         return NotFound("Student not found.");
        //     return Ok(updatedDocumentVerification);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var deleted = await _service.DeleteDocumentVerification(id);
        //     if (!deleted)
        //         return NotFound("DocumentVerification not found.");
        //     return Ok("DocumentVerification deleted successfully.");
        // }

        [HttpPost("{documentId}/{statusId}")]
        public async Task<IActionResult> VerifyDocument(int documentId, int statusId){
            var document=await _context.Documents.FirstOrDefaultAsync(d=> d.DocumentId==documentId);
            if(document==null){
                throw new Exception("Document is not found");
            }
        
           document.DocumentStatusTypeId=statusId;
           _context.Documents.Update(document);
           await _context.SaveChangesAsync();

           return Ok(document);
        }

    }
}
