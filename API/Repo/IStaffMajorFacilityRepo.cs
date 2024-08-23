using API.Models;

namespace API.Repo
{
    public interface IStaffMajorFacilityRepo
    {
        Task<StaffMajorFacility> GetByIdAsync(Guid id);
        Task<List<StaffMajorFacility>> GetAllAsync();
        Task AddAsync(StaffMajorFacility staffMajorFacility);
        Task UpdateAsync(StaffMajorFacility staffMajorFacility);
        Task DeleteAsync(Guid id);      
    }
}
