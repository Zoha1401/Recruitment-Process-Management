using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessManagementSystem.Service;
using RecruitmentProcessManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace RecruitmentProcessManagementSystem.Controllers
{
    [Authorize(Policy = "RecruiterPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _service;

        public RoleController(RoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _service.GetRoleById(id);
            if (role == null) 
                return NotFound("Student not found.");
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role role)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var addedRole = await _service.AddRole(role);
            return CreatedAtAction(nameof(GetById), new { id = addedRole.RoleId }, addedRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role role)
        {
            if (id != role.RoleId) 
                return BadRequest("ID mismatch.");
            var updatedRole = await _service.UpdateRole(role);
            if (updatedRole == null) 
                return NotFound("Student not found.");
            return Ok(updatedRole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteRole(id);
            if (!deleted) 
                return NotFound("Role not found.");
            return Ok("Role deleted successfully.");
        }
    }
}
