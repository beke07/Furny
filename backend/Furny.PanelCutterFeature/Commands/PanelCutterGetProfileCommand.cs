using Furny.PanelCutterFeature.Data;
using Furny.PanelCutterFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Furny.PanelCutterFeature.Commands
{
    public class PanelCutterGetProfileCommand : IRequest<PanelCutterProfileViewModel>
    {
        public PanelCutterGetProfileCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public static PanelCutterGetProfileCommand Create(string id)
            => new PanelCutterGetProfileCommand(id);
    }
}
