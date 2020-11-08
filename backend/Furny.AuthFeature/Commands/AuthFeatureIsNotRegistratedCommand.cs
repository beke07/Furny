using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureIsNotRegistratedCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public AuthFeatureIsNotRegistratedCommand(string email)
        {
            Email = email;
        }

        public static AuthFeatureIsNotRegistratedCommand Create(string email)
            => new AuthFeatureIsNotRegistratedCommand(email);
    }
}
