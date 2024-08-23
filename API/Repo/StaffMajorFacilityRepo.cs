using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class StaffMajorFacilityRepo : IStaffMajorFacilityRepo
    {
        private readonly ExamDistributionTestContext _context;
        public StaffMajorFacilityRepo(ExamDistributionTestContext context)
        { 
            _context = context;
        }
        public async Task AddAsync(StaffMajorFacility staffMajorFacility)
        {
            _context.StaffMajorFacilities.Add(staffMajorFacility);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var staffMajorFacility = await GetByIdAsync(id);
            if (staffMajorFacility != null)
            {
                _context.StaffMajorFacilities.Remove(staffMajorFacility);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StaffMajorFacility>> GetAllAsync()
        {
            return await _context.StaffMajorFacilities.ToListAsync();
        }

        public async Task<StaffMajorFacility> GetByIdAsync(Guid id)
        {
            return await _context.StaffMajorFacilities
             .Include(sm => sm.IdMajorFacilityNavigation)
             .Include(sm => sm.IdStaffNavigation)
             .FirstOrDefaultAsync(sm => sm.Id == id);
        }      

        public async Task UpdateAsync(StaffMajorFacility staffMajorFacility)
        {
            _context.StaffMajorFacilities.Update(staffMajorFacility);
            await _context.SaveChangesAsync();
        }
    }
}
