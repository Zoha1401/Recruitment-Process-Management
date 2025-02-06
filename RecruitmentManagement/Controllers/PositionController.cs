using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionService _service;

        public PositionController(PositionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Positions = await _service.GetAllPositions();
            return Ok(Positions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Position = await _service.GetPositionById(id);
            if (Position == null) 
                return NotFound("Student not found.");
            return Ok(Position);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPositionRequest Position)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var addedPosition = await _service.AddPosition(Position);
            return CreatedAtAction(nameof(GetById), new { id = addedPosition.Id }, addedPosition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Position Position)
        {
            if (id != Position.Id) 
                return BadRequest("ID mismatch.");
            var updatedPosition = await _service.UpdatePosition(Position);
            if (updatedPosition == null) 
                return NotFound("Student not found.");
            return Ok(updatedPosition);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeletePosition(id);
            if (!deleted) 
                return NotFound("Position not found.");
            return Ok("Position deleted successfully.");
        }
    }
}
