using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Repo
{
    public interface IMajorRepo
    {
        Task<List<Major>> GetMajorsByFacilityAsync(Guid facilityId);
    }
}
