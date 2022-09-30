using Ecommerce.Application.Common.DTOs.Stores;
using Ecommerce.Application.Stores.Commands.CreateStore;
using Ecommerce.Application.Stores.Commands.DeleteStore;
using Ecommerce.Application.Stores.Commands.UpdateStore;
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

        [HttpGet("{guid}", Name = "GetStoreByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string guid)
        {
            var response = await _mediator.Send(new GetStoreByIdQuery { Guid = guid });

            if (response.Error)
            {
                if (response.ErrorResponse.BadRequest)
                    return BadRequest(response.ErrorResponse);

                if (response.ErrorResponse.NotFound)
                    return NotFound();
            }

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateStoreDto store)
        {
            var response = await _mediator.Send(new CreateStoreCommand { Store = store });
            
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetStoreByIdAsync", new { guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] UpdateStoreDto store)
        {
            var response = await _mediator.Send(new UpdateStoreCommand { UpdateStoreDto = store });

            if (response.Error)
            {
                if (response.ErrorResponse.BadRequest)
                    return BadRequest(response.ErrorResponse);

                if (response.ErrorResponse.NotFound)
                    return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new DeleteStoreCommand { Guid = guid });

            if (response.Error)
            {
                if (response.ErrorResponse.BadRequest)
                    return BadRequest(response.ErrorResponse);

                if (response.ErrorResponse.NotFound)
                    return NotFound();
            }

            return NoContent();
        }
    }
}
