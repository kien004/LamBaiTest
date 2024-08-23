using API.Models;

namespace SeverPage.Service
{
    public interface IDepartmentFacilitySer
    {
        Task<List<DepartmentFacility>> GetAll();
        Task<DepartmentFacility> GetById(Guid id);
        Task Create(DepartmentFacility departmentFacility);
        Task Update(DepartmentFacility departmentFacility);
        Task Delete(Guid id);
    }
}
