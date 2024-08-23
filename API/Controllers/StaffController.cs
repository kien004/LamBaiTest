using API.Models;
using API.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStaffRepo _staffRepo;
        private readonly IFacilityRepo _facilityRepository;
        public StaffController(IStaffRepo staffRepo, IFacilityRepo facilityRepository)
		{
			_staffRepo = staffRepo;
            _facilityRepository = facilityRepository;
        }
		[HttpGet]
		public async Task<List<Staff>> GetAll()
		{
			return await _staffRepo.GetAll();
		}
		[HttpGet("{id}")]
		public async Task<Staff> GetById(Guid id)
		{
			return await _staffRepo.GetById(id);
		}
		[HttpPost]
		public async Task Create(Staff nv)
		{
			await _staffRepo.Create(nv);
		}
		[HttpPut]
		public async Task Update(Staff nv)
		{
			await _staffRepo.Update(nv);
		}
		[HttpDelete("{id}")]
		public async Task Delete(Guid id)
		{
			await _staffRepo.Delete(id);
		}

        [HttpPost("majorfacility")]
        public async Task<IActionResult> AddOrUpdateStaffMajorFacility(StaffMajorFacility staffMajorFacility)
        {
            // Kiểm tra các giá trị nullable và xử lý lỗi nếu cần
            var facilityId = staffMajorFacility.IdMajorFacilityNavigation?.IdDepartmentFacilityNavigation?.IdFacility;
            if (!facilityId.HasValue)
            {
                return BadRequest("Thiếu thông tin cơ sở.");
            }

            // Gọi phương thức với giá trị không nullable
            bool exists = await _staffRepo.HasMajorFacilityAsync(
                staffMajorFacility.IdStaff ?? Guid.Empty, // Hoặc sử dụng giá trị khác nếu cần
                facilityId.Value
            );

            if (exists)
            {
                return BadRequest("Nhân viên đã có bộ môn chuyên ngành trong cơ sở này.");
            }

            await _staffRepo.AddStaffMajorFacilityAsync(staffMajorFacility);
            return Ok();
        }

        // Xóa bộ môn chuyên ngành của nhân viên
        [HttpDelete("majorfacility/{id}")]
        public async Task<IActionResult> DeleteStaffMajorFacility(Guid id)
        {
            await _staffRepo.DeleteStaffMajorFacilityAsync(id);
            return Ok();
        }
    }
}
