using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorFacilityController : ControllerBase
    {
        private readonly IMajorFacilityRepo _repository;

        public MajorFacilityController(IMajorFacilityRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var majorFacility = await _repository.GetByIdAsync(id);
            if (majorFacility == null)
            {
                return NotFound();
            }
            return Ok(majorFacility);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var majorFacilities = await _repository.GetAllAsync();
            return Ok(majorFacilities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] MajorFacility majorFacility)
        {
            if (majorFacility == null)
            {
                return BadRequest();
            }
            await _repository.AddAsync(majorFacility);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = majorFacility.Id }, majorFacility);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] MajorFacility majorFacility)
        {
            if (majorFacility == null || majorFacility.Id != id)
            {
                return BadRequest();
            }

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(majorFacility);
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

        [HttpGet("bymajor/{majorId}")]
        public async Task<IActionResult> GetMajorFacilitiesByMajor(Guid majorId)
        {
            var majorFacilities = await _repository.GetMajorFacilitiesByMajorAsync(majorId);
            return Ok(majorFacilities);
        }
    }
}
