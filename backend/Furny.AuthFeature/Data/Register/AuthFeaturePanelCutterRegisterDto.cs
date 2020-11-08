using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furny.AuthFeature.Data
{
    public class AuthFeaturePanelCutterRegisterDto : AuthFeatureRegisterBaseDto
    {
        [Required]
        public string Opened { get; set; }

        public string Facebook { get; set; }

        public string ImageId { get; set; }

        public IList<string> Extras { get; set; }
    }
}
