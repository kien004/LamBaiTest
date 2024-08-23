using API.Models;

namespace SeverPage.Service
{
    public interface IStaffMajorFacilitySer
    {
        Task<StaffMajorFacility> GetByIdAsync(Guid id);
        Task<List<StaffMajorFacility>> GetAllAsync();
        Task AddAsync(StaffMajorFacility staffMajorFacility);
        Task UpdateAsync(StaffMajorFacility staffMajorFacility);
        Task DeleteAsync(Guid id);
    }
}
