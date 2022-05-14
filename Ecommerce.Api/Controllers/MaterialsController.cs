﻿using Ecommerce.Application.Materials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Materials.Commands;
using Ecommerce.Application.Common.DTOs.Materials;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("materiais")]
    public class MaterialsController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllMaterialsQuery());
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetMaterialByIdQuery { MaterialId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CreateMaterialDto material)
        {
            var response = await _mediator.Send(new CreateMaterialCommand { Material = material });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] UpdateMaterialDto material)
        {
            var response = await _mediator.Send(new UpdateMaterialCommand { Material = material });
            if (response.Error)
                return BadRequest(response.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteMaterialCommand { MaterialId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return NoContent();
        }
    }
}
