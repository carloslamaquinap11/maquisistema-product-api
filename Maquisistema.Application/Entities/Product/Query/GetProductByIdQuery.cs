using Maquisistema.Shared.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Application.Product
{
    public class GetProductByIdQuery:IRequest<ProductViewModel>
    {
        public int ProductId { get; set; }
    }
}
