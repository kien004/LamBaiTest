using API.Models;

namespace API.Repo
{
    public interface IMajorFacilityRepo
    {
        Task<MajorFacility> GetByIdAsync(Guid id);
        Task<List<MajorFacility>> GetAllAsync();
        Task AddAsync(MajorFacility majorFacility);
        Task UpdateAsync(MajorFacility majorFacility);
        Task DeleteAsync(Guid id);

        Task<List<MajorFacility>> GetMajorFacilitiesByMajorAsync(Guid majorId);
    }
}
