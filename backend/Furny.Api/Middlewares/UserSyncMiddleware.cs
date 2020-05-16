using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Middlewares
{
    public enum RoleTypes
    {
        Designer = 1,
        PanelCutter = 2
    }

    public class FurnyClaimTypes
    {
        public static string UserId = "user_id";

        public static string Name = "name";

        public static string Picture = "picture";

        public static string Email = "email";
    }

    public class UserSyncMiddleware
    {
        private const string RoleQueryString = "role";

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
                    if (!context.Request.Query.ContainsKey(RoleQueryString))
                    {
                        context.Response.StatusCode = StatusCodes.Status202Accepted;
                        return;
                    }

                    var userId = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.UserId).Value;
                    var name = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Name).Value;
                    var picture = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Picture).Value;
                    var role = context.Request.Query.First(e => e.Key == RoleQueryString).Value;

                    if (Enum.TryParse<RoleTypes>(role, ignoreCase: true, out var roleType))
                    {
                        if (roleType == RoleTypes.Designer)
                        {
                            await authService.RegisterDesigner(new DesignerRegisterDto() { Email = email, UserName = email, UserId = userId });
                        }
                        else if (roleType == RoleTypes.PanelCutter)
                        {
                            await authService.RegisterPanelCutter(new PanelCutterRegisterDto() { Email = email, UserName = email, UserId = userId });
                        }
                    }
                }
            }

            return;
        }
    }
}