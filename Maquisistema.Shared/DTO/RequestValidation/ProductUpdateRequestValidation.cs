using Maquisistema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public class ProductUpdateRequestValidation : IRequestValidation
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Currency { get; set; }

        private Validation Validation { get; set; }
        public ProductUpdateRequestValidation()
        {
            Validation = new Validation();
        }

        public bool IsValid()
        {
            List<int> allowedStatus = new List<int>();
            allowedStatus.Add((int)Product.KDStatus.Active);
            allowedStatus.Add((int)Product.KDStatus.Inactive);

            List<int> allowedCurrencies = new List<int>();
            allowedCurrencies.Add((int)Product.KDCurrency.USD);
            allowedCurrencies.Add((int)Product.KDCurrency.PEN);

            if (ProductId == null || ProductId == (int)Product.KDDefaultValues.ProductId)
            {
                var error = new ErrorValidation("Valid ProductId is required");
                Validation.Errors.Add(error);
            }

            if (string.IsNullOrEmpty(Name))
            {
                var error = new ErrorValidation("Name is required");
                Validation.Errors.Add(error);
            }

            if (Status == null)
            {
                var error = new ErrorValidation("Status is required");
                Validation.Errors.Add(error);
            }
            else if (!allowedStatus.Contains(Status))
            {
                var error = new ErrorValidation("Status allow just following values: " + string.Join(',', allowedStatus.ToArray()));
                Validation.Errors.Add(error);
            }

            if (Stock == null)
            {
                var error = new ErrorValidation("Stock is required");
                Validation.Errors.Add(error);
            }

            if (Price == null)
            {
                var error = new ErrorValidation("Price is required");
                Validation.Errors.Add(error);
            }

            if (Currency == null)
            {
                var error = new ErrorValidation("Currency is required");
                Validation.Errors.Add(error);
            }
            else if (!allowedCurrencies.Contains(Status))
            {
                var error = new ErrorValidation("Currency allow just following values: " + string.Join(',', allowedCurrencies.ToArray()));
                Validation.Errors.Add(error);
            }

            Validation.IsValid = Validation.Errors.Count == 0;
            return Validation.IsValid;
        }
        public IEnumerable<ErrorValidation> GetErrors()
        {
            return Validation.Errors;
        }
    }
}
