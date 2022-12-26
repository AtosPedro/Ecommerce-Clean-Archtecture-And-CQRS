using Ecommerce.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Products.Commands;
using Ecommerce.Application.Common.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Domain.Common.Constants;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllMaterialsQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetProductByIdAsync")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int guid)
        {
            var response = await _mediator.Send(new GetMaterialByIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateProductDto material)
        {
            var response = await _mediator.Send(new CreateProductCommand { Product = material });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetProductByIdAsync", new { Guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateProductDto material)
        {
            var response = await _mediator.Send(new UpdateProductCommand { Material = material });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string Guid)
        {
            var response = await _mediator.Send(new DeleteProductCommand { Guid = Guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
