using Furny.Common.Commands;

namespace Furny.AuthFeature.Commands
{
    public class AuthFeatureGerUserRoleCommand : GetCommand<string>
    {
        public string Email { get; set; }

        public AuthFeatureGerUserRoleCommand(string email)
        {
            Email = email;
        }

        public static AuthFeatureGerUserRoleCommand Create(string email)
            => new AuthFeatureGerUserRoleCommand(email);
    }
}
