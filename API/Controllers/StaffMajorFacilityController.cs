using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMajorFacilityController : ControllerBase
    {
        private readonly IStaffMajorFacilityRepo _repository;

        public StaffMajorFacilityController(IStaffMajorFacilityRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var staffMajorFacility = await _repository.GetByIdAsync(id);
            if (staffMajorFacility == null)
            {
                return NotFound();
            }
            return Ok(staffMajorFacility);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var staffMajorFacilities = await _repository.GetAllAsync();
            return Ok(staffMajorFacilities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] StaffMajorFacility staffMajorFacility)
        {
            if (staffMajorFacility == null)
            {
                return BadRequest();
            }
            await _repository.AddAsync(staffMajorFacility);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = staffMajorFacility.Id }, staffMajorFacility);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StaffMajorFacility staffMajorFacility)
        {
            if (staffMajorFacility == null || staffMajorFacility.Id != id)
            {
                return BadRequest();
            }

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(staffMajorFacility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
