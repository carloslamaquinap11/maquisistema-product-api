using Maquisistema.Shared.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Application.Entities.Product
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductViewModel>>
    {
    }
}
