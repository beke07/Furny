using AutoMapper;
using Furny.Data;
using Furny.Filters;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> IsNotRegistratedAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }

        public async Task<string> LoginAsync(LoginDto login)
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

        public async Task RegisterAsync(RegisterDto register)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(register), register.Password);

            if (!result.Succeeded)
            {
                throw new HttpResponseException(result.Errors, HttpStatusCode.InternalServerError);
            }
        }

        public async Task CreateUserAsync(FirebaseUserDto user)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(user));

            if (!result.Succeeded)
            {
                throw new HttpResponseException(result.Errors, HttpStatusCode.InternalServerError);
            }
        }
    }
}
