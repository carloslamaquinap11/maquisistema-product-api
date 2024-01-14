using AutoMapper;
using Maquisistema.Domain.Repository;
using Maquisistema.Shared.ViewModel;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Maquisistema.Application.Entities.Product
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Product> products = await _productRepository.GetAllAsync();

            IEnumerable<ProductViewModel> productsViewModel = _mapper.Map<IEnumerable<Domain.Entities.Product>, IEnumerable<ProductViewModel>>(products);

            return productsViewModel;
        }
    }
}
