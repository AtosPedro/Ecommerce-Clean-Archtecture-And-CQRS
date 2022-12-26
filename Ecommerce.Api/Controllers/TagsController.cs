using Ecommerce.Application.Common.DTOs.Tags;
using Ecommerce.Application.Tags.Commands;
using Ecommerce.Application.Tags.Commands.CreateTag;
using Ecommerce.Application.Tags.Commands.DeleteTag;
using Ecommerce.Application.Tags.Commands.UpdateTag;
using Ecommerce.Application.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    public class TagsController : Controller
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllTagsQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetTagByIdAsync")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new GetTagByIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateTagDto Tag)
        {
            var response = await _mediator.Send(new CreateTagCommand { Tag = Tag });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetTagByIdAsync", new { Guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateTagDto Tag)
        {
            var response = await _mediator.Send(new UpdateTagCommand { Tag = Tag });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string Guid)
        {
            var response = await _mediator.Send(new DeleteTagCommand { Guid = Guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
