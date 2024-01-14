using AutoMapper;
using Maquisistema.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Application.Common.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductViewModel>();


        }
    }
}
