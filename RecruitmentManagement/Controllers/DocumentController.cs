using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using ExcelDataReader;
using RecruitmentProcessManagementSystem.Data;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _service;
        private readonly RecruitmentDbContext _context;

        public DocumentController(DocumentService service, RecruitmentDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Documents = await _service.GetAllDocuments();
            if (Documents == null)
            {
                return NotFound("There are no candidates");
            }
            return Ok(Documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Document = await _service.GetDocumentById(id);
            if (Document == null)
                return NotFound("Student not found.");
            return Ok(Document);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DocumentDTO Document)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedDocument = await _service.UploadDocument(Document);
            return CreatedAtAction(nameof(GetById), new { id = addedDocument.DocumentId }, addedDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentDTO Document)
        {
            var updatedDocument = await _service.UpdateDocument(id, Document);
            if (updatedDocument == null)
                return NotFound("Student not found.");
            return Ok(updatedDocument);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteDocument(id);
            if (!deleted)
                return NotFound("Document not found.");
            return Ok("Document deleted successfully.");
        }

    }
}
