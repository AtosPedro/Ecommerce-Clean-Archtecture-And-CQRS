﻿using Ecommerce.Application.Users.Commands.CreateUser;
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
        //[Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetUserByIdAsync")]
        //[Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new GetUsersByIdQuery { Guid = guid });
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
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserDto user)
        {
            var response = await _mediator.Send(new CreateUserCommand { User = user });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute(
                "GetUserByIdAsync",
                new { Guid = response?.Data.Guid }, 
                response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> PutAsync([FromBody] UpdateUserDto user)
        {
            var response = await _mediator.Send(new UpdateUserCommand { User = user });
            if (response.Error)
            {
                if (response.ErrorResponse.BadRequest)
                    return BadRequest(response.ErrorResponse);

                if (response.ErrorResponse.NotFound)
                    return NotFound();
            }

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = UserRole.Administrator)]
        public async Task<IActionResult> DeleteAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new DeleteUserCommand { Guid = guid });
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
