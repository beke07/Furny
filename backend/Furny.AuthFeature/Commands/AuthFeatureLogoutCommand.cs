using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureLogoutCommand : IRequest
    {
        public AuthFeatureLogoutCommand()
        { }

        public static AuthFeatureLogoutCommand Create()
            => new AuthFeatureLogoutCommand();
    }
}
