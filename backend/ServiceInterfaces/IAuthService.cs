using Furny.Data;
using Furny.Models;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto login);

        Task RegisterDesigner(DesignerRegisterDto registerDto);

        Task RegisterPanelCutter(PanelCutterRegisterDto registerDto);

        Task<ObjectId> RegisterAsync<T, U>(U register, string role)
             where T : ApplicationUser
             where U : RegisterBaseDto;

        Task LogoutAsync();

        Task<bool> IsNotRegistratedAsync(string email);
    }
}
