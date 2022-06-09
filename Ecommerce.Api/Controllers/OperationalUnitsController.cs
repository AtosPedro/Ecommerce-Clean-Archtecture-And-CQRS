using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnit ;
using Ecommerce.Application.OperationalUnits.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/unidades")]
    public class OperationalUnitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationalUnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllOperationalUnitsQuery());

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetOperationalUnitByIdQuery { OperationalUnitId = id });

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperationalUnitDto unit)
        {
            var response = await _mediator.Send(new CreateOperationalUnitCommand { OperationalUnit = unit });

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
