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
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  CreateUserDto user)
        {
            var result = await _mediator.Send(new CreateUserCommand{ User = user });
            return View();
        }
    }
}
