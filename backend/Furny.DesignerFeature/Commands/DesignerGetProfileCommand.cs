using Furny.DesignerFeature.ViewModels;
using MediatR;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerGetProfileCommand : IRequest<DesignerProfileViewModel>
    {
        public DesignerGetProfileCommand()
        { }

        public DesignerGetProfileCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static DesignerGetProfileCommand Create(string id)
            => new DesignerGetProfileCommand(id);
    }
}
