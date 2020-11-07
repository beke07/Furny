using AutoMapper;
using Furny.Data;
using Furny.Filters;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System.Net;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> IsNotRegistratedAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }

        public async Task<string> LoginAsync(LoginCommand login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                return _configuration.GenerateToken(user);
            }

            throw new HttpResponseException("Username or password is wrong!", HttpStatusCode.BadRequest);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ObjectId> RegisterAsync<T, U>(U register, string role)
            where T: ApplicationUser
            where U: RegisterBaseCommand
        {
            var user = _mapper.Map<T>(register);

            IdentityResult result;

            if (string.IsNullOrEmpty(register.UserId))
            {
                result = await _userManager.CreateAsync(user, register.Password);
            }
            else
            {
                result = await _userManager.CreateAsync(user);
            }

            if(!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new ApplicationRole(role));
            }

            await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                throw new HttpResponseException(result.Errors, HttpStatusCode.InternalServerError);
            }

            return user.Id;
        }

        public async Task RegisterDesigner(DesignerRegisterCommand registerDto)
        {
            await RegisterAsync<Designer, DesignerRegisterCommand>(registerDto, RoleNames.Designer);
        }

        public async Task RegisterPanelCutter(PanelCutterRegisterCommand registerDto)
        {
            await RegisterAsync<PanelCutter, PanelCutterRegisterCommand>(registerDto, RoleNames.PanelCutter);         
        }
    }
}
