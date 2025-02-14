using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RecruitmentManagement.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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
            if (Positions == null)
            {
                return NotFound("No positions are found");
            }
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
        public async Task<IActionResult> Add([FromBody] PositionRequest Position)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedPosition = await _service.AddPosition(Position);
            return CreatedAtAction(nameof(GetById), new { id = addedPosition.PositionId }, addedPosition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PositionRequest Position)
        {
            var updatedPosition = await _service.UpdatePosition(id, Position);
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

        [HttpPost("defineInterviewRounds/{positionId}")]

        public async Task<IActionResult> DefineInterviewRounds(int positionId, [FromBody] ICollection<InterviewForPosition> interviewForPositions)
        {
            if (interviewForPositions == null)
            {
                return BadRequest("Interviews not specified");
            }
            var position = await _service.DefineInterviewRounds(positionId, interviewForPositions);
            if (position == null)
            {
                return NotFound("Position Not found");
            }

            return Ok("Interview rounds were defined");
        }


        [HttpPost("assignReviewer/{positionId}/{reviewerId}")]
        public async Task<IActionResult> AssignReviewer(int positionId, int reviewerId)
        {
            var authHeader=Request.Headers.Authorization;
            if(string.IsNullOrEmpty(authHeader)){
                return Unauthorized("Authorization header is missing");
            }
            Console.WriteLine(authHeader);
            var position = await _service.AssignReviewer(positionId, reviewerId);
            if (position == null)
            {
                return NotFound("Position Not found");
            }
            return Ok("Reviewer has been assigned");
        }

        [HttpPost("changeStatus/{positionId}")]
        public async Task<IActionResult> ChangeStatus(int positionId, [FromBody] PositionStatusChange positionStatusChange)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (positionStatusChange == null)
            {
                return BadRequest("No proper status change for position is specified");
            }
            var position = await _service.ChangeStatus(positionId, positionStatusChange);
            if (position == null)
            {
                return NotFound("Position Not found");
            }
            return Ok("The status of the position has been changed");
        }

        [HttpPut("updateInterviewRounds/{positionId}")]
        public async Task<Position> UpdateInterviewRounds(int positionId, ICollection<InterviewForPosition> interviewForPositions)
        {

            return await _service.UpdateInterviewRounds(positionId, interviewForPositions);
        }


        [HttpGet("getPositionsForReviewer/{reviewerId}")]
        public async Task<IEnumerable<Position>> GetPositionsForReviewer(int reviewerId)
        {
            return await _service.GetPositionsForReviewer(reviewerId);
        }
        
        [HttpPost("addPositionSkills/{positionId}")]
         public async Task<Position> AddPositionSkills(int positionId, [FromBody] List<SkillRequest> skillRequests){
            return await _service.AddPositionSkills(positionId, skillRequests);
         }


        // public async Task<IActionResult> Patch(int positionId, [FromBody] JsonPatchDocument<Position> patch)
        // {
        //     var fromDb = await _service.GetPositionById(positionId);
        //     if(fromDb==null){
        //         throw new ArgumentException("Position is not found");
        //     }
        //     var original = fromDb;
        //     patch.ApplyTo(fromDb, ModelState);

        //     var isValid = TryValidateModel(fromDb);
        //     if (!isValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     await _service.UpdatePosition(fromDb);
        //     var model = new
        //     {
        //         original,
        //     };
        //     return Ok(model);
        // }
         
         [HttpGet("getPositionStatusTypes")]
         public async Task<IEnumerable<RecruitmentManagement.Model.PositionStatusType>> GetAllPositionStatusTypes()
        {
            return await _service.GetAllPositionStatusTypes();
        }

        [HttpGet("getAssignedReviewer/{positionId}")]
        public async Task<IActionResult> GetAssignedReviewer(int positionId){
            if(positionId<=0){
                return NotFound("Please give correct ID");
            }
            var reviewer=await _service.GetAssignedReviewer(positionId);
            if(reviewer==null){
                return NotFound("No reviewer found for this position");
            }
            return Ok(reviewer);
        }



    }
}