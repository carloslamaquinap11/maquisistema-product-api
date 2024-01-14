using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Maquisistema.Shared.DTO;
using Microsoft.Extensions.Logging;
using MediatR;
using Maquisistema.Application.Product;
using System;
using System.Reflection;
using Maquisistema.Application.Entities.Product;
using AutoMapper;
using System.Diagnostics;
using Maquisistema.Shared.ViewModel;

namespace Producto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        public ProductController(ILogger<ProductController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var watch = new Stopwatch();
            watch.Start();
            var apiResponse = new ApiResponse();
            _logger.LogInformation("***Starting GetAll");
            IActionResult result;
            try
            {
                GetAllProductQuery getAllProductQuery = new GetAllProductQuery();
                var products = await _mediator.Send(getAllProductQuery);
                apiResponse.Data = products;
                result = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"***Exception GetAll: " + ex.Message);
                result = Forbid("System error in GetById, please contact to admin");
            }
            watch.Stop();
            _logger.LogInformation("***Finishing GetAll -> ResponseTime: " + watch.ElapsedMilliseconds + "ms");
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var watch = new Stopwatch();
            watch.Start();
            _logger.LogInformation("***Starting GetById: " + id);
            var apiResponse = new ApiResponse();
            IActionResult result;
            try
            {
                GetProductByIdQuery getByIdQuery = new GetProductByIdQuery();
                getByIdQuery.ProductId = id;
                var product = await _mediator.Send(getByIdQuery);

                if (product.ProductId == (int)ProductViewModel.DefaultValues.DefaultProductId)
                {
                    apiResponse.Message = "Product not found";
                    result = NotFound(apiResponse);
                }
                else
                {
                    apiResponse.Data = product;
                    result = Ok(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"***Exception GetById: " +ex.Message);
                result = Forbid("System error in GetById, please contact to admin");
            }
            watch.Stop();
            _logger.LogInformation("***Finishing GetById -> ResponseTime: "+ watch.ElapsedMilliseconds+"ms");
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductInsertRequestValidation product)
        {
            var watch = new Stopwatch();
            watch.Start();
            _logger.LogInformation("***Starting Insert: " + product);
            var apiResponse = new ApiResponse();
            IActionResult result;
            try
            {
                if (!product.IsValid())
                {
                    apiResponse.Message = string.Join('-', product.GetErrors());
                    return BadRequest(apiResponse);
                }
                InsertProductCommand insertProductCommand = _mapper.Map<InsertProductCommand>(product);

                var newProduct = await _mediator.Send(insertProductCommand);
                var productInsertResponse = _mapper.Map<ProductInsertResponse>(newProduct);
                apiResponse.Data = productInsertResponse;
                result = Created(MethodBase.GetCurrentMethod().ToString(), apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"***Exception Insert: " + ex.Message);
                result = Forbid("System error in GetById, please contact to admin");
            }
            watch.Stop();
            _logger.LogInformation("***Finishing Insert -> ResponseTime: "+watch.ElapsedMilliseconds + "ms");
            return await Task.FromResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequestValidation product)
        {
            var watch = new Stopwatch();
            watch.Start();
            _logger.LogInformation("***Starting Update: " + product);
            
            var apiResponse = new ApiResponse();
            IActionResult result;
            try
            {
                if (!product.IsValid())
                {
                    apiResponse.Message = string.Join('-', product.GetErrors());
                    return BadRequest(apiResponse);
                }

                UpdateProductCommand updateProductCommand = _mapper.Map<UpdateProductCommand>(product);
                var updatedProduct = await _mediator.Send(updateProductCommand);
                var productUpdateResponse = _mapper.Map<ProductUpdateResponse>(updatedProduct);
                apiResponse.Data = productUpdateResponse;
                result = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"***Exception Update: " + ex.Message);
                result = Forbid("System error in GetById, please contact to admin");
            }
            watch.Stop();
            _logger.LogInformation("***Finishing Update -> ResponseTime: " + watch.ElapsedMilliseconds + "ms");
            return await Task.FromResult(result);
        }
    }
}
