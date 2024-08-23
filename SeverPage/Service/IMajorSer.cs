using API.Models;

namespace SeverPage.Service
{
    public interface IMajorSer
    {
        Task<List<Major>> GetMajorsByFacilityAsync(Guid facilityId);
    }
}
