using Ecommerce.Application.Common.DTOs.Suppliers;
using Ecommerce.Application.Suppliers.Commands;
using Ecommerce.Application.Suppliers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("fornecedores")]
    public class SuppliersController : Controller
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery { SupplierId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateSupplierDto supplier)
        {
            var response = await _mediator.Send(new CreateSupplierCommand { Supplier = supplier });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateSupplierDto supplier)
        {
            var response = await _mediator.Send(new UpdateSupplierCommand { Supplier = supplier });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteSupplierCommand { SupplierId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
