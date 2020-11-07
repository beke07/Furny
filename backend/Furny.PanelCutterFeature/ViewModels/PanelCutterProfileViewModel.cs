using System.Collections.Generic;

namespace Furny.PanelCutterFeature.ViewModels
{
    public class PanelCutterProfileViewModel
    {
        public string UserName { get; set; }

        public string ImageId { get; set; }

        public string AddressId { get; set; }

        public string StreetAndHouse { get; set; }

        public string Phone { get; set; }

        public string Opened { get; set; }

        public string Facebook { get; set; }

        public IList<string> Extras { get; set; }
    }
}
