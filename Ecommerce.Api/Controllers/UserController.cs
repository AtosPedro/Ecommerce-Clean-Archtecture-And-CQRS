using Ecommerce.Application.Common.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Domain.Common.Constants;

namespace Ecommerce.Api.Controllers
{
    [Route("v1/usuarios")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserDto user)
        {
            return null;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto user)
        {
            return null;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Administrator)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return null;
        }
    }
}
