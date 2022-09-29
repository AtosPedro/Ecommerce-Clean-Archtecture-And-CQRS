using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Suppliers.Commands;
using Ecommerce.Application.Suppliers.Queries;
using Ecommerce.Domain.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/fornecedores")]
    public class SuppliersController : Controller
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            return Ok(response.Data);
        }

        [HttpGet("{guid}", Name = "GetSupplierByIdAsync")]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new GetSupplierByIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateSupplierDto supplier)
        {
            var response = await _mediator.Send(new CreateSupplierCommand { Supplier = supplier });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetSupplierByIdAsync", new { id = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateSupplierDto supplier)
        {
            var response = await _mediator.Send(new UpdateSupplierCommand { UpdateSupplierDto = supplier });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{guid}")]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new DeleteSupplierCommand { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
