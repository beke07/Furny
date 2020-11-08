using Furny.AuthFeature.Data;
using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureLoginCommand : IRequest<string>
    {
        public AuthFeatureLoginDto Login { get; set; }

        public AuthFeatureLoginCommand(AuthFeatureLoginDto login)
        {
            Login = login;
        }

        public static AuthFeatureLoginCommand Create(AuthFeatureLoginDto login)
            => new AuthFeatureLoginCommand(login);
    }
}
