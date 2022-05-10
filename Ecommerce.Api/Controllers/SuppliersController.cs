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
        public async Task<IEnumerable<Supplier>> Get()
        {
            var response = await _mediator.Send(new GetAllSuppliersQuery());
            return response.Data;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post()
        {
            return View();
        }

        [HttpPut]
        public ActionResult Put(int id)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
