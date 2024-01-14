using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public class ProductUpdateResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Currency { get; set; }
    }
}
