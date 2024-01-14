using Maquisistema.Domain.Entities;
using Maquisistema.Domain.Repository;
using Maquisistema.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquisistema.Infrastructure.Repository
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        

        public ProductRepository(MaquisistemaDbContext maquisistemaDbContext):base(maquisistemaDbContext)
        {
            
        }
        public IDictionary<string, string> GetAllProductStatus()
        {
            var enumDictionary = new Dictionary<string, string>
                    {
                        { ((int)Domain.Entities.Product.KDStatus.Inactive).ToString(), Domain.Entities.Product.KDStatus.Inactive.ToString() },
                        { ((int)Domain.Entities.Product.KDStatus.Active).ToString(), Domain.Entities.Product.KDStatus.Active.ToString() }
                    };

            return enumDictionary;
        }

        public IDictionary<string, string> GetAllProductCurrencies()
        {
            var enumDictionary = new Dictionary<string, string>
                    {
                        { ((int)Domain.Entities.Product.KDCurrency.USD).ToString(), Domain.Entities.Product.KDCurrency.USD.ToString() },
                        { ((int)Domain.Entities.Product.KDCurrency.PEN).ToString(), Domain.Entities.Product.KDCurrency.PEN.ToString() }
                    };

            return enumDictionary;
        }
    }
}
