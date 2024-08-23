using API.Models;

namespace API.Repo
{
	public interface IStaffRepo
	{
		Task<List<Staff>> GetAll();
		Task<Staff> GetById(Guid id);
		Task Create(Staff nv);
		Task Update(Staff nv);
		Task Delete(Guid id);

        Task<bool> HasMajorFacilityAsync(Guid staffId, Guid facilityId);
        Task AddStaffMajorFacilityAsync(StaffMajorFacility staffMajorFacility);
        Task DeleteStaffMajorFacilityAsync(Guid id);
    }
}
