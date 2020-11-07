using Furny.Common.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.Model.Common.Commands
{
    public class GetPanelCutterAdsCommand : IRequest<IList<AdViewModel>>
    {
        public GetPanelCutterAdsCommand(string country)
        {
            Country = country;
        }

        public string Country { get; }

        public static GetPanelCutterAdsCommand Create(string country)
            => new GetPanelCutterAdsCommand(country);
    }
}
