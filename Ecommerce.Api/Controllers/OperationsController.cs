using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Operations.Commands.CreateOperation;
using Ecommerce.Application.Operations.Commands.DeleteOperation;
using Ecommerce.Application.Operations.Commands.UpdateOperation;
using Ecommerce.Application.Operations.Queries;
using Ecommerce.Domain.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/operacoes")]
    public class OperationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllOperationsQuery());

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{id}", Name = "GetByIdAsync")]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetOperationByIdQuery { OperationId = id });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperationDto operation)
        {
            var response = await _mediator.Send(new CreateOperationCommand { Operation = operation });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetByIdAsync", new { id = response?.Data?.Id ?? 0 }, response?.Data);
        }

        [HttpPut]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> PutAsync([FromBody] UpdateOperationDto operation)
        {
            var response = await _mediator.Send(new UpdateOperationCommand { Operation = operation });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteOperationCommand { OperationId = id });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
