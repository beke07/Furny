using Furny.Data;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto login);

        Task RegisterAsync(RegisterDto register);

        Task LogoutAsync();

        Task<bool> IsNotRegistratedAsync(string email);

        Task CreateUserAsync(FirebaseUserDto user);
    }
}
