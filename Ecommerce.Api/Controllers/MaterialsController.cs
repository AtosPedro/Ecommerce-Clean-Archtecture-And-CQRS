using Ecommerce.Application.Materials.Commands;
using Ecommerce.Application.Materials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("materiais")]
    public class MaterialsController : Controller
    {
        private readonly IMediator _mediator;
        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_mediator.Send(new GetAllMaterialQuery()));
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] GetMaterialByIdQuery query)
        {
            try
            {
                return Ok(_mediator.Send(query));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMaterialCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateMaterialCommand command)
        {
            try
            {
                return Ok( await _mediator.Send(command));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteMaterialCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch
            {
                return BadRequest();
            }            
        }
    }
}
