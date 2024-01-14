using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Domain.Services
{
    public interface IProductDiscountService
    {
        Task<decimal> GetDiscountByProductId(int productId);
    }
}
