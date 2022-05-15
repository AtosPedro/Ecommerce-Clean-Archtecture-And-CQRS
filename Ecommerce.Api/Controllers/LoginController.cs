using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Users.Commands.AuthenticateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/login")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] AutenticatedUserDto user)
        {
            var response = await _mediator.Send(new AuthenticateUserCommand { User = user });

            if (response.Error)
                return BadRequest(response.Message);

            return Ok(new { response.Data, response.Message });
        }

    }
}
