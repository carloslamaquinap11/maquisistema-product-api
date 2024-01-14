using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO.Response
{
    public class GetProductByIdResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public int Currency { get; set; }
        public string CurrencyName { get; set; }
    }
}
