using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class MajorRepo : IMajorRepo
    {
        private readonly ExamDistributionTestContext _context;
        public MajorRepo(ExamDistributionTestContext context)
        {
            _context = context;
        }
        public async Task<List<Major>> GetMajorsByFacilityAsync(Guid facilityId)
        {
            return await _context.Majors
            .Where(m => m.MajorFacilities.Any(mf => mf.IdDepartmentFacilityNavigation.IdFacility == facilityId))
            .ToListAsync();
        }       
    }
}
