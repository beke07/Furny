using Furny.AuthFeature.Data;
using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureRegisterPanelCutterCommand : IRequest
    {
        public AuthFeaturePanelCutterRegisterDto Register { get; set; }

        public AuthFeatureRegisterPanelCutterCommand(AuthFeaturePanelCutterRegisterDto register)
        {
            Register = register;
        }

        public static AuthFeatureRegisterPanelCutterCommand Create(AuthFeaturePanelCutterRegisterDto register)
            => new AuthFeatureRegisterPanelCutterCommand(register);
    }
}
