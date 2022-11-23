using Ecommerce.Application.Common.DTOs.Carts;
using Ecommerce.Application.Carts.Commands;
using Ecommerce.Application.Carts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Carts.Commands.CreateCart;
using Ecommerce.Application.Carts.Commands.UpdateCart;

namespace Ecommerce.Api.Controllers
{
    public class CartsController : Controller
    {
        private readonly IMediator _mediator;

        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllCartsQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetCartByIdAsync")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int guid)
        {
            var response = await _mediator.Send(new GetCartByUserIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateCartDto Cart)
        {
            var response = await _mediator.Send(new CreateCartCommand { Cart = Cart });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetCartByIdAsync", new { Guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateCartDto Cart)
        {
            var response = await _mediator.Send(new UpdateCartCommand { Cart = Cart });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string Guid)
        {
            var response = await _mediator.Send(new DeleteCartCommand { Guid = Guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
