using AutoMapper;
using Maquisistema.Domain.Repository;
using Maquisistema.Domain.Services;
using Maquisistema.Shared.ViewModel;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Maquisistema.Application.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductDiscountService _productDiscountService;
        private readonly IConfiguration _configuration;

        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper, IMemoryCache memoryCache, IProductDiscountService productDiscountService, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productDiscountService = productDiscountService;
            _configuration = configuration;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            Domain.Entities.Product product = _memoryCache.GetOrCreate(nameof(Domain.Entities.Product) +
                request.ProductId.ToString(), entry =>
                {
                    var minutesToExpire = Convert.ToInt32(_configuration["Cache:MinutesToExpire"]);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(minutesToExpire);
                    return _productRepository.GetByIdAsync(request.ProductId).Result;
                }
            );
            
            if (product != null)
            {
                productViewModel = _mapper.Map<Domain.Entities.Product, ProductViewModel>(product);

                Dictionary<string, string> productStatus = (Dictionary<string, string>)_memoryCache.GetOrCreate("ProductStatusDictionary", entry =>
                {
                    var minutesToExpire = Convert.ToInt32(_configuration["Cache:MinutesToExpire"]);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(minutesToExpire);

                    var productStatus = _productRepository.GetAllProductStatus();
                    return productStatus;
                });

                

                Dictionary<string, string> productCurrencies = (Dictionary<string, string>)_memoryCache.GetOrCreate("ProductCurrenciesDictionary", entry =>
                {
                    var minutesToExpire = Convert.ToInt32(_configuration["Cache:MinutesToExpire"]);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(minutesToExpire);

                    var productStatus = _productRepository.GetAllProductCurrencies();
                    return productStatus;
                });

                productViewModel.StatusName = productStatus[(productViewModel.Status).ToString()];
                productViewModel.CurrencyName = productCurrencies[(productViewModel.Currency).ToString()];
                productViewModel.Discount = await _productDiscountService.GetDiscountByProductId(product.ProductId);
                productViewModel.FinalPrice = productViewModel.Price * (100 - productViewModel.Discount) / 100;
            }

            return productViewModel;
        }
    }
}
