using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.ViewModel
{
    public class ProductViewModel
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

        public ProductViewModel()
        {
            ProductId = (int)DefaultValues.DefaultProductId;
        }

        public enum DefaultValues
        {
            DefaultProductId = -1
        }
    }
}
