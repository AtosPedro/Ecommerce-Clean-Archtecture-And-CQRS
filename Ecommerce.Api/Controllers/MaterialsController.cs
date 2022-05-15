﻿using Ecommerce.Application.Materials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Application.Materials.Commands;
using Ecommerce.Application.Common.DTOs.Materials;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class MaterialsController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllMaterialsQuery());
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetMaterialByIdQuery { MaterialId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostAsync([FromBody] CreateMaterialDto material)
        {
            var response = await _mediator.Send(new CreateMaterialCommand { Material = material });
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> PutAsync([FromBody] UpdateMaterialDto material)
        {
            var response = await _mediator.Send(new UpdateMaterialCommand { Material = material });
            if (response.Error)
                return BadRequest(response.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteMaterialCommand { MaterialId = id });
            if (response.Error)
                return BadRequest(response.Message);

            return NoContent();
        }
    }
}
