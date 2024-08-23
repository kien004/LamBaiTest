using API.Models;

namespace API.Repo
{
    public interface IDepartmentFacilityRepo
    {
        Task<List<DepartmentFacility>> GetAll();
        Task<DepartmentFacility> GetById(Guid id);
        Task Create(DepartmentFacility departmentFacility);
        Task Update(DepartmentFacility departmentFacility);
        Task Delete(Guid id);
    }
}
