using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace API.Repo
{
    public class DepartmentFacilityRepo : IDepartmentFacilityRepo
    {
        private readonly ExamDistributionTestContext _context;
        public DepartmentFacilityRepo(ExamDistributionTestContext context)
        {
            _context = context;
        }

        public async Task Create(DepartmentFacility departmentFacility)
        {
             _context.DepartmentFacilities.Add(departmentFacility);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var departmentFacility = await GetById(id);
            if (departmentFacility != null)
            {
                _context.DepartmentFacilities.Remove(departmentFacility);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentFacility>> GetAll()
        {
            return await _context.DepartmentFacilities.ToListAsync();
        }

        public async Task<DepartmentFacility> GetById(Guid id)
        {
            return await _context.DepartmentFacilities
           .Include(df => df.MajorFacilities)
           .FirstOrDefaultAsync(df => df.Id == id);
        }

        public async Task Update(DepartmentFacility departmentFacility)
        {
            _context.DepartmentFacilities.Update(departmentFacility);
            await _context.SaveChangesAsync();
        }
    }
}
