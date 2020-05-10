using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register/designer")]
        public async Task<IActionResult> RegisterDesginer(DesignerRegisterDto registerDto)
        {
            await _authService.RegisterDesigner(registerDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register/panel-cutter")]
        public async Task<IActionResult> RegisterPanelCutter(PanelCutterRegisterDto registerDto)
        {
            await _authService.RegisterPanelCutter(registerDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
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