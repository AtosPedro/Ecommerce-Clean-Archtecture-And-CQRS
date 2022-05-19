using System.Security.Claims;

namespace Ecommerce.Infrastructure.Common.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetId(this ClaimsPrincipal principal)
        {
            var id = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            Int32.TryParse(id?.Value, out int idUser);
            return idUser;
        }

        public static string GetEmail(this ClaimsPrincipal principal)
        {
            var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            return email?.Value;
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            var username = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            return username?.Value;
        }
    }
}
