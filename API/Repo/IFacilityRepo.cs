using API.Models;

namespace API.Repo
{
    public interface IFacilityRepo
    {
        Task<List<Facility>> GetAll();
    }
}
