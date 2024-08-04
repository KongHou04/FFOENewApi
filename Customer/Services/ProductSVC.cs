using Customer.DTOs;
using System.Net.Http;
using System.Net.Http.Json;

namespace Customer.Services
{
    public class ProductSVC(HttpClient httpClient)
    {
        public IEnumerable<ProductDTO>? Products { get; set; } = [];

        private readonly string apiHost = "https://localhost:7032/api/Products";

        public async Task GetAllValidAsync()
        {
            try
            {
                var data = await httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>(apiHost);
                this.Products = data;
            }
            catch
            {
            }
        }

        public async Task<ProductDTO?> GetByIdAsync(Guid id)
        {
            try
            {
                var data = await httpClient.GetFromJsonAsync<ProductDTO?>(apiHost + "/" + id);
                return data;
            }
            catch
            {
                return null;
            }
        }

    }
}
