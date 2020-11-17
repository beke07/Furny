using Furny.AuthFeature.Commands;
using Furny.AuthFeature.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MediatorControllerBase
    {
        public AuthController(IMediator mediator) : base(mediator)
        { }

        [AllowAnonymous]
        [HttpPost("register/designer")]
        public async Task RegisterDesigner(AuthFeatureDesignerRegisterDto registerDto)
            => await SendAsync(AuthFeatureRegisterDesignerCommand.Create(registerDto));

        [AllowAnonymous]
        [HttpPost("register/panel-cutter")]
        public async Task RegisterPanelCutter(AuthFeaturePanelCutterRegisterDto registerDto)
            => await SendAsync(AuthFeatureRegisterPanelCutterCommand.Create(registerDto));

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<string> Login(AuthFeatureLoginDto loginDto)
            => await SendAsync(AuthFeatureLoginCommand.Create(loginDto));

        [AllowAnonymous]
        [HttpGet("user-roles/{email}")]
        public async Task<string> GetRole(string email)
            => await SendAsync(AuthFeatureGerUserRoleCommand.Create(email));

        [Authorize]
        [HttpPost("logout")]
        public async Task Logout()
            => await SendAsync(AuthFeatureLogoutCommand.Create());
    }
}