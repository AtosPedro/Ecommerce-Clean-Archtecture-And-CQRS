using AutoMapper;
using Ecommerce.Application.Suppliers.DTOs;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
        }
    }
}
