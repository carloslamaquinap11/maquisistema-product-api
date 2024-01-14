using AutoMapper;
using Maquisistema.Domain.Repository;
using Maquisistema.Shared.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maquisistema.Application.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = _mapper.Map<Domain.Entities.Product>(request);
            var product = await _productRepository.UpdateAsync(productToUpdate);
            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
