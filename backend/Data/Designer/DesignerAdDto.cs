using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Data.Designer
{
    public class DesignerAdDto
    {
        public string PanelCutterId { get; set; }

        public string PanelCutterUserName { get; set; }

        public string PanelCutterImageId { get; set; }

        public string Text { get; set; }

        public string HourAgo { get; set; }
    }
}