using API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Repo
{
	public class StaffRepo : IStaffRepo
	{
		private readonly ExamDistributionTestContext _context;
		public StaffRepo(ExamDistributionTestContext context)
		{
			_context = context;
		}

		public async Task AddStaffMajorFacilityAsync(StaffMajorFacility staffMajorFacility)
		{
			_context.StaffMajorFacilities.Add(staffMajorFacility);
			await _context.SaveChangesAsync();
		}

		public async Task Create(Staff nv)
		{
			await _context.Staff.AddAsync(nv);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var nv = await GetById(id);
			_context.Staff.Remove(nv);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Staff>> GetAll()
		{
			return await _context.Staff.ToListAsync();
		}

		public async Task<Staff> GetById(Guid id)
		{
			return await _context.Staff.FindAsync(id);
		}

		public async Task<bool> HasMajorFacilityAsync(Guid staffId, Guid facilityId)
		{
			return await _context.StaffMajorFacilities
			.Include(smf => smf.IdMajorFacilityNavigation)
				.ThenInclude(mf => mf.IdDepartmentFacilityNavigation)
			.AnyAsync(smf => smf.IdStaff == staffId
							 && smf.IdMajorFacilityNavigation.IdDepartmentFacilityNavigation.IdFacility == facilityId);
		}

		public async Task Update(Staff nv)
		{
			_context.Staff.Update(nv);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteStaffMajorFacilityAsync(Guid id)
		{
			var staffMajorFacility = await _context.StaffMajorFacilities.FindAsync(id);
			if (staffMajorFacility != null)
			{
				_context.StaffMajorFacilities.Remove(staffMajorFacility);
				await _context.SaveChangesAsync();
			}
		}
	}
}
