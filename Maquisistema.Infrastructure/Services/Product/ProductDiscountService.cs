using Maquisistema.Domain.Services;
using Maquisistema.Shared.DTO.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maquisistema.Infrastructure.Services
{
    public class ProductDiscountService : IProductDiscountService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public ProductDiscountService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<decimal> GetDiscountByProductId(int productId)
        {
            var productDiscount = new ProductDiscount();
            var mockApiClient = _httpClientFactory.CreateClient("MockApiClient");
            var productDiscountPath = _configuration["Services:ProductDiscountAPI"];
            var httpRespondeMessage = await mockApiClient.GetAsync(productDiscountPath + productId.ToString());

            if (httpRespondeMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpRespondeMessage.Content.ReadAsStringAsync();
                productDiscount = JsonConvert.DeserializeObject<ProductDiscount>(contentStream);
            }
            return productDiscount.Discount;
        }
    }
}
