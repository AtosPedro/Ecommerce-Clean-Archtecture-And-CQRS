using Ecommerce.Application.Suppliers.Commands;
using Ecommerce.Application.Suppliers.Queries;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("fornecedores")]
    public class SuppliersController : Controller
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateSupplierCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Error)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        //[HttpPut]
        //public async Task<ActionResult> Put([FromBody] UpdateSupplierCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    if (response.Error)
        //        return BadRequest(response.Message);

        //    return Ok(response.Data);
        //}

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
