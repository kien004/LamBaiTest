using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class FacilityRepo : IFacilityRepo
    {
        private readonly ExamDistributionTestContext _context;
        public FacilityRepo(ExamDistributionTestContext context)
        {
            _context = context;
        }
        public async Task<List<Facility>> GetAll()
        {
           return await _context.Facilities.ToListAsync();  
        }
    }
}
