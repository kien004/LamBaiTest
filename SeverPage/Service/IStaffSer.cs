using API.Models;

namespace SeverPage.Service
{
	public interface IStaffSer
	{
		Task<List<Staff>> GetAll();
		Task<Staff> GetById(Guid id);
		Task Create(Staff nv);
		Task Update(Staff nv);
		Task Delete(Guid id);
        Task<bool> HasMajorFacilityAsync(Guid staffId, Guid facilityId);
        Task AddStaffMajorFacilityAsync(StaffMajorFacility staffMajorFacility);
        Task DeleteStaffMajorFacilityAsync(Guid id);
		Task<List<StaffMajorFacility>> GetStaffMajorFacilitiesAsync();
		Task<List<MajorFacility>> GetMajorFacilitiesAsync(Guid facilityId);
		Task<List<Facility>> GetFacilitiesAsync();
		Task<List<Major>> GetMajorsAsync(Guid majorFacilityId);
    }
}
