using MediatR;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureIsNotRegistratedCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public string Role { get; set; }

        public AuthFeatureIsNotRegistratedCommand(string email, string role)
        {
            Email = email;
            Role = role;
        }

        public static AuthFeatureIsNotRegistratedCommand Create(string email, string role)
            => new AuthFeatureIsNotRegistratedCommand(email, role);
    }
}
