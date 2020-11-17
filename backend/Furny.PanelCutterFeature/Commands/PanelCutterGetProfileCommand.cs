using Furny.PanelCutterFeature.Data;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.PanelCutterFeature.Commands
{
    public class PanelCutterGetProfileCommand : IRequest<PanelCutterProfileViewModel>
    {
        public PanelCutterGetProfileCommand(string id, string email)
        {
            Id = id;
            Email = email;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public static PanelCutterGetProfileCommand Create(string id,string email = null)
            => new PanelCutterGetProfileCommand(id, email);
    }
}
