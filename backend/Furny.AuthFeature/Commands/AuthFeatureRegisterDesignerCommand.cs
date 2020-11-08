using Furny.AuthFeature.Data;
using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureRegisterDesignerCommand : IRequest
    {
        public AuthFeatureDesignerRegisterDto Register { get; set; }

        public AuthFeatureRegisterDesignerCommand(AuthFeatureDesignerRegisterDto register)
        {
            Register = register;
        }

        public static AuthFeatureRegisterDesignerCommand Create(AuthFeatureDesignerRegisterDto register)
            => new AuthFeatureRegisterDesignerCommand(register);
    }
}
