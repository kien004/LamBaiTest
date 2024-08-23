using API.Models;

namespace SeverPage.Service
{
    public class DepartmentFacilitySer : IDepartmentFacilitySer
    {
        private readonly HttpClient _httpClient;
        public DepartmentFacilitySer(HttpClient httpClient)
        {
            
            _httpClient = httpClient;
        }

        public async Task Create(DepartmentFacility departmentFacility)
        {
            await _httpClient.PostAsJsonAsync("api/DepartmentFacility", departmentFacility);
        }

        public async Task Delete(Guid id)
        {
            await _httpClient.DeleteAsync($"api/DepartmentFacility/{id}");
        }

        public async Task<List<DepartmentFacility>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentFacility>>("api/DepartmentFacility");
        }

        public async Task<DepartmentFacility> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<DepartmentFacility>($"api/DepartmentFacility/{id}");
        }

        public async Task Update(DepartmentFacility departmentFacility)
        {
            await _httpClient.PutAsJsonAsync("api/DepartmentFacility", departmentFacility);
        }
    }
}
