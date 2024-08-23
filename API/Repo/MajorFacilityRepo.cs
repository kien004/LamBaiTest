using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class MajorFacilityRepo : IMajorFacilityRepo
    {
        private readonly ExamDistributionTestContext _context;
        public MajorFacilityRepo(ExamDistributionTestContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MajorFacility majorFacility)
        {
            _context.MajorFacilities.Add(majorFacility);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var majorFacility = await GetByIdAsync(id);
            if (majorFacility != null)
            {
                _context.MajorFacilities.Remove(majorFacility);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MajorFacility>> GetAllAsync()
        {
            return await _context.MajorFacilities.ToListAsync();
        }

        public async Task<MajorFacility> GetByIdAsync(Guid id)
        {
            return await _context.MajorFacilities
           .Include(mf => mf.IdDepartmentFacilityNavigation)
           .Include(mf => mf.StaffMajorFacilities)
           .FirstOrDefaultAsync(mf => mf.Id == id);
        }

        public async Task<List<MajorFacility>> GetMajorFacilitiesByMajorAsync(Guid majorId)
        {
            return await _context.MajorFacilities
            .Where(mf => mf.IdMajor == majorId)
            .ToListAsync();
        }

        public async Task UpdateAsync(MajorFacility majorFacility)
        {
            _context.MajorFacilities.Update(majorFacility);
            await _context.SaveChangesAsync();
        }
    }
}
