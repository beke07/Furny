using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Middlewares
{
    public class FurnyClaimTypes
    {
        public static string UserId = "user_id";

        public static string Name = "name";

        public static string Picture = "picture";

        public static string Email = "email";
    }

    public class UserSyncMiddleware
    {
        private readonly RequestDelegate _next;

        public UserSyncMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authService)
        {
            var token = context.Request.Headers["Authorization"]
                    .ToString()
                    .Replace("Bearer ", string.Empty);

            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                var claims = securityToken.Claims.ToList();
                var email = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Email).Value;

                if (await authService.IsNotRegistratedAsync(email))
                {
                    var userId = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.UserId).Value;
                    var name = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Name).Value;
                    var picture = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Picture).Value;

                    await authService.CreateUserAsync(new FirebaseUserDto() { Email = email, Name = name, ImageUrl = picture, UserId = userId });
                }
            }

            return;
        }
    }
}