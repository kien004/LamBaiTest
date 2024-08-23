using API.Models;

namespace SeverPage.Service
{
    public interface IFacilitySer
    {
        Task<List<Facility>> GetAll();
    }
}
