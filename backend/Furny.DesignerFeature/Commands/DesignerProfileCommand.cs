using Furny.DesignerFeature.ViewModels;
using MediatR;

namespace Furny.DesignerFeature.Commands
{
    public class DesignerProfileCommand : IRequest<DesignerProfileViewModel>
    {
        public string UserName { get; set; }

        public string ImageId { get; set; }

        public string AddressId { get; set; }

        public string StreetAndHouse { get; set; }

        public string Phone { get; set; }
    }
}
