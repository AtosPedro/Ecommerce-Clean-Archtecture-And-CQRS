//using Ecommerce.Application.Logs.Queries;
using Ecommerce.Domain.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("v1/logs")]
    public class LogController : Controller
    {
        private readonly IMediator _mediator;

        public LogController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        //[HttpGet]
        //[Authorize(Roles = UserRoles.Administrator)]
        //public async Task<IActionResult> Get()
        //{
        //    var response = await _mediator.Send(new GetAllLogsQuery());
        //    if (response.Error)
        //        return BadRequest(response.Message);

        //    return Ok(response.Data);
        //}
    }
}
