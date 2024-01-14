using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO.Services
{
    public class ProductDiscount
    {
        public int ProductId { get; set; }
        public decimal Discount { get; set; }
        public ProductDiscount()
        {
            ProductId = 0;
            Discount = 0.0M;
        }
    }
}
