using Customer.DTOs;
using System.Net.Http.Json;

namespace Customer.Services
{
    public class CategorySVC(HttpClient httpClient)
    {
        public IEnumerable<CategoryDTO>? Categorys { get; set; } = [];

        private readonly string apiHost = "https://localhost:7032/api/Categories";

        public async Task GetAllValidAsync()
        {
            try
            {
                var data = await httpClient.GetFromJsonAsync<IEnumerable<CategoryDTO>>(apiHost);
                this.Categorys = data;
            }
            catch
            {

            }   
        }

        public async Task<CategoryDTO?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await httpClient.GetFromJsonAsync<CategoryDTO?>(apiHost + "/" + id);
                return data;
            }
            catch
            {
                return null;
            }
        }

    }
}
