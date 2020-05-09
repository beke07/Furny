using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furny.Data
{
    public class PanelCutterRegisterDto : RegisterBaseDto
    {
        [Required]
        public string Opened { get; set; }

        public string Facebook { get; set; }

        public string ImageId { get; set; }

        public IList<string> Extras { get; set; }
    }
}
