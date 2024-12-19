using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string apiEndPoint = "/api/products/";
        private readonly JsonSerializerOptions _options;
        private ProductViewModel productViewModel;
        private IEnumerable<ProductViewModel> productsVM;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(apiEndPoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productsVM = await JsonSerializer
                        .DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productsVM;
        }

        public async Task<ProductViewModel> FindProductById(int id)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using (var response = await client.GetAsync(apiEndPoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productViewModel = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productViewModel;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel product)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(product),
                Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndPoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productViewModel = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productViewModel;
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel product)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            ProductViewModel productUpdate = new ProductViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndPoint, product))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    productUpdate = await JsonSerializer
                        .DeserializeAsync<ProductViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return productUpdate;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var client = _clientFactory.CreateClient("ProductApi");

            using (var response = await client.DeleteAsync(apiEndPoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}