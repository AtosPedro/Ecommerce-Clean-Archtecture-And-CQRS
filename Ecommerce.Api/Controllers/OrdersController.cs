using Ecommerce.Application.Common.DTOs.Orders;
using Ecommerce.Application.Orders.Commands;
using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Commands.DeleteOrder;
using Ecommerce.Application.Orders.Commands.UpdateOrder;
using Ecommerce.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllOrdersQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetOrderByIdAsync")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int guid)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateOrderDto Order)
        {
            var response = await _mediator.Send(new CreateOrderCommand { Order = Order });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetOrderByIdAsync", new { Guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateOrderDto Order)
        {
            var response = await _mediator.Send(new UpdateOrderCommand { Order = Order });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string Guid)
        {
            var response = await _mediator.Send(new DeleteOrderCommand { Guid = Guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
