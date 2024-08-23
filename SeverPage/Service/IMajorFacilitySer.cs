using API.Models;

namespace SeverPage.Service
{
    public interface IMajorFacilitySer
    {
        Task<MajorFacility> GetByIdAsync(Guid id);
        Task<List<MajorFacility>> GetAllAsync();
        Task AddAsync(MajorFacility majorFacility);
        Task UpdateAsync(MajorFacility majorFacility);
        Task DeleteAsync(Guid id);

        Task<List<MajorFacility>> GetMajorFacilitiesByMajorAsync(Guid majorId);

        Task<IEnumerable<MajorFacility>> GetMajorFacilitiesByFacilityIdAsync(Guid facilityId);
        Task<IEnumerable<Major>> GetMajorFieldsByMajorFacilityIdAsync(Guid majorFacilityId);
    }
}
