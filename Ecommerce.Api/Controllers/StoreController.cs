﻿using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Stores.Commands.CreateStore;
using Ecommerce.Application.Stores.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/lojas")]
    public class StoresController : Controller
    {
        private readonly IMediator _mediator;

        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllStoresQuery());

            if (response.Error)
                return BadRequest(response.ErrorResponse);
            
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateStoreDto store)
        {
            var response = await _mediator.Send(new CreateStoreCommand { Store = store });
            
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetByIdAsync", new { id = response?.Data?.Id ?? 0 }, response?.Data);
        }
    }
}
