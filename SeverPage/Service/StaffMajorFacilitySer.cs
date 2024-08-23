using API.Models;

namespace SeverPage.Service
{
    public class StaffMajorFacilitySer : IStaffMajorFacilitySer
    {
        private readonly HttpClient _httpClient;
        public StaffMajorFacilitySer(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }

        public async Task AddAsync(StaffMajorFacility staffMajorFacility)
        {
            await _httpClient.PostAsJsonAsync("api/StaffMajorFacility", staffMajorFacility);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/StaffMajorFacility/{id}");
        }

        public async Task<List<StaffMajorFacility>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StaffMajorFacility>>("api/StaffMajorFacility");
        }

        public async Task<StaffMajorFacility> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<StaffMajorFacility>($"api/StaffMajorFacility/{id}");
        }

        public async Task UpdateAsync(StaffMajorFacility staffMajorFacility)
        {
            await _httpClient.PutAsJsonAsync("api/StaffMajorFacility", staffMajorFacility);
        }
    }
}
