using API.Models;
using Azure;

namespace SeverPage.Service
{
	public class StaffSer : IStaffSer
	{
		private HttpClient _httpClient;
		public StaffSer(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        //public async Task AddStaffMajorFacilityAsync(StaffMajorFacility staffMajorFacility)
        //{
        //    HttpResponseMessage response;
        //    if (staffMajorFacility.Id == Guid.Empty)
        //    {
        //        response = await _httpClient.PostAsJsonAsync("Staff/MajorFacility", staffMajorFacility);
        //    }
        //    else
        //    {
        //        response = await _httpClient.PutAsJsonAsync($"Staff/MajorFacility/{staffMajorFacility.Id}", staffMajorFacility);
        //    }

        //    response.EnsureSuccessStatusCode();
        //}

        public async Task Create(Staff nv)
		{
			await _httpClient.PostAsJsonAsync("api/Staff", nv);
		}

		public async Task Delete(Guid id)
		{
			await _httpClient.DeleteAsync($"api/Staff/{id}");
		}

        //public async Task DeleteStaffMajorFacilityAsync(Guid id)
        //{
        //    var response = await _httpClient.DeleteAsync($"Staff/MajorFacility/{id}");
        //    response.EnsureSuccessStatusCode();
        //}

        public async Task<List<Staff>> GetAll()
		{
			return await _httpClient.GetFromJsonAsync<List<Staff>>("api/Staff");
		}

		public async Task<Staff> GetById(Guid id)
		{
			return await _httpClient.GetFromJsonAsync<Staff>($"api/Staff/{id}");
		}

        public async Task<bool> HasMajorFacilityAsync(Guid staffId, Guid facilityId)
        {
            var response = await _httpClient.GetAsync($"Staff/hasmajorfacility/{staffId}/{facilityId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task Update(Staff nv)
		{
			await _httpClient.PutAsJsonAsync("api/Staff", nv);
		}

        public async Task<List<Facility>> GetFacilitiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Facility>>("api/Facility");
        }

        public async Task<List<MajorFacility>> GetMajorFacilitiesAsync(Guid facilityId)
        {
            return await _httpClient.GetFromJsonAsync<List<MajorFacility>>($"api/MajorFacility/{facilityId}");
        }

        public async Task<List<Major>> GetMajorsAsync(Guid majorFacilityId)
        {
            return await _httpClient.GetFromJsonAsync<List<Major>>($"api/Major/{majorFacilityId}");
        }

        public async Task AddStaffMajorFacilityAsync(StaffMajorFacility staffMajorFacility)
        {
            await _httpClient.PostAsJsonAsync("api/StaffMajorFacility", staffMajorFacility);
        }

        public async Task DeleteStaffMajorFacilityAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/staffmajorfacilities/{id}");
        }

        public async Task<List<StaffMajorFacility>> GetStaffMajorFacilitiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StaffMajorFacility>>("api/staffmajorfacilities");
        }
    }
}
