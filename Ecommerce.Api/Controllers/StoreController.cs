using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Users.Commands.CreateUser;
using Ecommerce.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/lojas")]
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            if (response.Error)
                return BadRequest(response.Message);
            
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserDto user)
        {
            var response = await _mediator.Send(new CreateUserCommand{ User = user });
            
            if (response.Error)
                return BadRequest(response.Message);
            
            return Ok(response.Data);
        }
    }
}
