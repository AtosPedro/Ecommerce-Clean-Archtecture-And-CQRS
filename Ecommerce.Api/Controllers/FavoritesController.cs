using Ecommerce.Application.Common.DTOs.Favorites;
using Ecommerce.Application.Favorites.Commands.CreateFavorite;
using Ecommerce.Application.Favorites.Commands.DeleteFavorite;
using Ecommerce.Application.Favorites.Commands.UpdateFavorite;
using Ecommerce.Application.Favorites.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("favorites")]
    public class FavoritesController : Controller
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllFavoritesQuery());
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpGet("{Guid}", Name = "GetFavoriteByIdAsync")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] string guid)
        {
            var response = await _mediator.Send(new GetFavoriteByIdQuery { Guid = guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpPost]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PostAsync([FromBody] CreateFavoriteDto Favorite)
        {
            var response = await _mediator.Send(new CreateFavoriteCommand { Favorite = Favorite });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return CreatedAtRoute("GetFavoriteByIdAsync", new { Guid = response?.Data?.Guid }, response?.Data);
        }

        [HttpPut]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> PutAsync([FromBody] UpdateFavoriteDto Favorite)
        {
            var response = await _mediator.Send(new UpdateFavoriteCommand { Favorite = Favorite });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return Ok(response.Data);
        }

        [HttpDelete("{Guid}")]
        //[Authorize(Roles = $"{UserRole.Administrator},{UserRole.Salesman}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] string Guid)
        {
            var response = await _mediator.Send(new DeleteFavoriteCommand { Guid = Guid });
            if (response.Error)
                return BadRequest(response.ErrorResponse);

            return NoContent();
        }
    }
}
