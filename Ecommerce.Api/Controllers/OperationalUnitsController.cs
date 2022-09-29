﻿using Ecommerce.Application.Common.DTOs.OperationalUnits;
using Ecommerce.Application.OperationalUnits.Commands.CreateOperationalUnit;
using Ecommerce.Application.OperationalUnits.Commands.DeleteOperationalUnit;
using Ecommerce.Application.OperationalUnits.Commands.UpdateOperationalUnit;
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
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetOperationalUnitByIdQuery { OperationalUnitId = id });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateOperationalUnitDto unit)
        {
            var response = await _mediator.Send(new CreateOperationalUnitCommand { CreateOperationalUnitDto = unit });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetByIdAsync", new { id = response?.Data?.Id ?? 0 }, response?.Data);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateOperationalUnitDto unit)
        {
            var response = await _mediator.Send(new UpdateOperationalUnitCommand { OperationalUnit = unit });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var dto = new DeleteOperationalUnitDto { Id = id };
            var response = await _mediator.Send(new DeleteOperationalUnitCommand { OperationalUnitDto = dto });

            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
