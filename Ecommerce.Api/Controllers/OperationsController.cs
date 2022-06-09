using Ecommerce.Application.Common.DTOs.Operations;
using Ecommerce.Application.Operations.Commands.CreateOperation;
using Ecommerce.Application.Operations.Queries;
using Ecommerce.Domain.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> GetByAsync()
        {
            var response = await _mediator.Send(new GetOperationByIdQuery());

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet]
        [Authorize(Roles = $"{UserRoles.Administrator},{UserRoles.Salesman}")]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperationDto operation)
        {
            var response = await _mediator.Send(new CreateOperationCommand { Operation = operation });

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
