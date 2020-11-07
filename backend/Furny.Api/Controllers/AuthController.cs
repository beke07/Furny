using Furny.Data;
using Furny.ServiceInterfaces;
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
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService,
            IMediator mediator) : base(mediator)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register/designer")]
        public async Task<IActionResult> RegisterDesginer(DesignerRegisterCommand registerDto)
        {
            await _authService.RegisterDesigner(registerDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register/panel-cutter")]
        public async Task<IActionResult> RegisterPanelCutter(PanelCutterRegisterCommand registerDto)
        {
            await _authService.RegisterPanelCutter(registerDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok();
        }
    }
}