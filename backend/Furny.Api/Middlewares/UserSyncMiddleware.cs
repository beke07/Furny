using Furny.AuthFeature.Commands;
using Furny.AuthFeature.Data;
using Furny.Common.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
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

        public async Task InvokeAsync(HttpContext context, IMediator mediator)
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

                if (!context.Request.Query.ContainsKey(RoleQueryString))
                {
                    throw new HttpResponseException("Role megadása kötelező!", HttpStatusCode.BadRequest);
                }

                var role = context.Request.Query.First(e => e.Key == RoleQueryString).Value;
                
                if (await mediator.Send(AuthFeatureIsNotRegistratedCommand.Create(email, role)))
                {
                    var userId = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.UserId).Value;
                    var name = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Name).Value;
                    var picture = claims.FirstOrDefault(e => e.Type == FurnyClaimTypes.Picture).Value;

                    if (Enum.TryParse<RoleTypes>(role, ignoreCase: true, out var roleType))
                    {
                        if (roleType == RoleTypes.Designer)
                        {
                            await mediator.Send(AuthFeatureRegisterDesignerCommand.Create(new AuthFeatureDesignerRegisterDto() { Email = email, Name = name, UserId = userId }));
                        }
                        else if (roleType == RoleTypes.PanelCutter)
                        {
                            await mediator.Send(AuthFeatureRegisterPanelCutterCommand.Create(new AuthFeaturePanelCutterRegisterDto() { Email = email, Name = name, UserId = userId }));
                        }
                    }   
                }
            }

            return;
        }
    }
}