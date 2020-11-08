using Furny.AuthFeature.Data;
using Furny.Model;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Furny.AuthFeature.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(AuthFeatureLoginDto login);

        Task RegisterDesigner(AuthFeatureDesignerRegisterDto registerDto);

        Task RegisterPanelCutter(AuthFeaturePanelCutterRegisterDto registerDto);

        Task LogoutAsync();

        Task<bool> IsNotRegistratedAsync(string email);
    }
}
