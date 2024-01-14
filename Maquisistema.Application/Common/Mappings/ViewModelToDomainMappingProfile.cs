using AutoMapper;
using Maquisistema.Application.Product;
using Maquisistema.Shared.DTO;
using Maquisistema.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Application.Common.Mappings
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Domain.Entities.Product>();
            CreateMap<ProductInsertRequestValidation, InsertProductCommand>();
            CreateMap<InsertProductCommand, Domain.Entities.Product>();
            CreateMap<ProductViewModel, ProductInsertResponse>();
            CreateMap<ProductViewModel, ProductUpdateResponse>();
        }
    }
}
