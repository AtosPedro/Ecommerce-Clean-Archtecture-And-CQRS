﻿using AutoMapper;
using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Suppliers.Queries
{
    public record GetAllSuppliersQuery : BaseRequest, IRequestWrapper<IEnumerable<ReadSupplierDto>>
    {
        public int SupplierId { get; set; }
    }

    public class GetAllSuppliersQueryHandler : IHandlerWrapper<GetAllSuppliersQuery, IEnumerable<ReadSupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ReadSupplierDto>>> Handle(
            GetAllSuppliersQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                var suppliers = await _supplierRepository.GetAll(cancellationToken);
                var readSuppliers = _mapper.Map<IEnumerable<ReadSupplierDto>>(suppliers);
                return Response.Ok(readSuppliers, "Get Suppliers");
            }
            catch (Exception ex)
            {
                return Response.Fail<IEnumerable<ReadSupplierDto>>(
                    $"Fail to create a user. Message: {ex.Message}", 
                    ErrorHandler.HandleApplicationError(ex));
            }
        }
    }
}
