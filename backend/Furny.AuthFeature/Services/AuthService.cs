using AutoMapper;
using Furny.AuthFeature.Data;
using Furny.AuthFeature.ServiceInterfaces;
using Furny.Common.Filters;
using Furny.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Furny.AuthFeature.Services
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

        public async Task<bool> IfRegisteredCheckInRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return true;

            else
            {
                if (!await _userManager.IsInRoleAsync(user, role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            return false;
        }

        public async Task<string> LoginAsync(AuthFeatureLoginDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(login.UserName);
                var role = await _roleManager.FindByIdAsync(user.Roles.First().ToString());
                return _configuration.GenerateToken(user, role);
            }

            throw new HttpResponseException("E-mail cím vagy jelszó helytelen!", HttpStatusCode.BadRequest);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<ObjectId> RegisterAsync<T, U>(U register, string role)
            where T : ApplicationUser
            where U : AuthFeatureRegisterBaseDto
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

            await _userManager.AddToRoleAsync(user, role);

            if (!result.Succeeded)
            {
                throw new HttpResponseException(result.Errors, HttpStatusCode.InternalServerError);
            }

            return user.Id;
        }

        public async Task RegisterDesigner(AuthFeatureDesignerRegisterDto registerDto)
        {
            await RegisterAsync<Designer, AuthFeatureDesignerRegisterDto>(registerDto, RoleNames.Designer);
        }

        public async Task RegisterPanelCutter(AuthFeaturePanelCutterRegisterDto registerDto)
        {
            await RegisterAsync<PanelCutter, AuthFeaturePanelCutterRegisterDto>(registerDto, RoleNames.PanelCutter);
        }

        public async Task<string> GetRoleByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || user.Roles == null || user.Roles.Count == 0) 
                return null;

            var role = await _roleManager.FindByIdAsync(user.Roles.First().ToString());

            return role.Name;
        }
    }
}
