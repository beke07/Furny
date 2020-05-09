using Furny.Data;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IFileHandlerService _fileHandlerService;
        private readonly IAuthService _authService;

        public AuthController(
            IFileHandlerService fileHandlerService,
            IAuthService authService)
        {
            _fileHandlerService = fileHandlerService;
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
        [HttpPost("register/panelcutter")]
        public async Task<IActionResult> RegisterPanelCutter(PanelCutterRegisterDto registerDto)
        {
            await _authService.RegisterPanelCutter(registerDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register/panelcutter/logo")]
        public async Task<IActionResult> UploadFIle(IFormFile file)
        {
            return Ok(new { imageId = await _fileHandlerService.UploadFileAsync(file) });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            return Ok(new { token });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok();
        }
    }
}