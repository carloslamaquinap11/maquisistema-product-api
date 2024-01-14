using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Maquisistema.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Currency { get; set; }

        public enum KDStatus
        {
            [Description("Inactive")]
            Inactive = 0,
            [Description("Ative")]
            Active = 1
        }
        public enum KDCurrency
        {
            [Description("USD")]
            USD = 0,
            [Description("PEN")]
            PEN = 1
        }
        public enum KDDefaultValues
        {
            ProductId = 0
        }
    }
}
