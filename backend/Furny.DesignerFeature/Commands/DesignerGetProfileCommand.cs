using Furny.DesignerFeature.ViewModels;
using MediatR;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetProfileCommand : IRequest<DesignerProfileViewModel>
    {
        public DesignerGetProfileCommand()
        { }

        public DesignerGetProfileCommand(string id, string email)
        {
            Id = id;
            Email = email;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public static DesignerGetProfileCommand Create(string id, string email = null)
            => new DesignerGetProfileCommand(id, email);
    }
}
