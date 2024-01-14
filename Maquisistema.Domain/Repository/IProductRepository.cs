using Maquisistema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maquisistema.Domain.Repository
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        IDictionary<string, string> GetAllProductStatus();
        IDictionary<string, string> GetAllProductCurrencies();
    }
}
