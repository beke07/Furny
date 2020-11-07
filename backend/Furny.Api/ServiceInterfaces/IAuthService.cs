using Furny.Data;
using Furny.Models;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginCommand login);

        Task RegisterDesigner(DesignerRegisterCommand registerDto);

        Task RegisterPanelCutter(PanelCutterRegisterCommand registerDto);

        Task<ObjectId> RegisterAsync<T, U>(U register, string role)
             where T : ApplicationUser
             where U : RegisterBaseCommand;

        Task LogoutAsync();

        Task<bool> IsNotRegistratedAsync(string email);
    }
}
