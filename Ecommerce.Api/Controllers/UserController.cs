using Ecommerce.Application.Users.Commands.CreateUser;
using Ecommerce.Application.Users.Commands.UpdateUser;
using Ecommerce.Application.Users.Commands.DeleteUser;
using Ecommerce.Application.Common.DTOs.Users;
using Ecommerce.Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Domain.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Ecommerce.Api.Controllers
{
    [Route("v1/usuarios")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUsersByIdQuery { Id = id });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto user)
        {
            var response = await _mediator.Send(new CreateUserCommand { User = user });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDto user)
        {
            var response = await _mediator.Send(new UpdateUserCommand { User = user });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var dto = new DeleteUserDto { Id = id };
            var response = await _mediator.Send(new DeleteUserCommand { DeleteUserDto = dto });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }
    }
}
