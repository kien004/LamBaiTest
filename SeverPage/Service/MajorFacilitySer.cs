using API.Models;

namespace SeverPage.Service
{
    public class MajorFacilitySer : IMajorFacilitySer
    {
        private readonly HttpClient _httpClient;
        public MajorFacilitySer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddAsync(MajorFacility majorFacility)
        {
            await _httpClient.PostAsJsonAsync("api/MajorFacility", majorFacility);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/MajorFacility/{id}");
        }

        public async Task<List<MajorFacility>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<MajorFacility>>("api/MajorFacility");
        }

        public async Task<MajorFacility> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<MajorFacility>($"api/MajorFacility/{id}");
        }

        public async Task<IEnumerable<MajorFacility>> GetMajorFacilitiesByFacilityIdAsync(Guid facilityId)
        {
            var response = await _httpClient.GetAsync($"majorfacilities/facility/{facilityId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<MajorFacility>>();

        }

        public Task<List<MajorFacility>> GetMajorFacilitiesByMajorAsync(Guid majorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Major>> GetMajorFieldsByMajorFacilityIdAsync(Guid majorFacilityId)
        {
            var response = await _httpClient.GetAsync($"majors/majorfacility/{majorFacilityId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Major>>();

        }

        public async Task UpdateAsync(MajorFacility majorFacility)
        {
            await _httpClient.PutAsJsonAsync("api/MajorFacility", majorFacility);
        }
    }
}
