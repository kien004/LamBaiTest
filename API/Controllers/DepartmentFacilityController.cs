using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentFacilityController : ControllerBase
    {
        private readonly IDepartmentFacilityRepo _repository;
        public DepartmentFacilityController(IDepartmentFacilityRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var departmentFacility = await _repository.GetById(id);
            if (departmentFacility == null)
            {
                return NotFound();
            }
            return Ok(departmentFacility);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var departmentFacilities = await _repository.GetAll();
            return Ok(departmentFacilities);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] DepartmentFacility departmentFacility)
        {
            if (departmentFacility == null)
            {
                return BadRequest();
            }
            await _repository.Create(departmentFacility);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = departmentFacility.Id }, departmentFacility);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] DepartmentFacility departmentFacility)
        {
            if (departmentFacility == null || departmentFacility.Id != id)
            {
                return BadRequest();
            }

            var existing = await _repository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.Update(departmentFacility);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existing = await _repository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }       
    }
}
