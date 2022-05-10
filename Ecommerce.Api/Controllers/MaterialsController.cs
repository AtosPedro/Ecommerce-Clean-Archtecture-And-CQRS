using Ecommerce.Application.Common.Communication;
using Ecommerce.Application.Materials.Commands;
using Ecommerce.Application.Materials.DTOs;
using Ecommerce.Application.Materials.Queries;
using Ecommerce.Domain.Entities;
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
        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _mediator.Send(new GetAllMaterialQuery());
        }

        [HttpGet("{id}")]
        public async Task<Material> GetById([FromRoute] GetMaterialByIdQuery query)
        {
            try
            {
                return await _mediator.Send(query);
            }
            catch
            {
                return null;
            }
        }

        //[HttpPost]
        //public async Task<Response<Material>> Post([FromBody] CreateMaterialCommand command)
        //{
        //    //return await _mediator.Send(command);
        //}

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateMaterialCommand command)
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
