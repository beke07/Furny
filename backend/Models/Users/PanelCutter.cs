using AspNetCore.Identity.MongoDbCore.Models;
using Furny.Data;
using Furny.Filters;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace Furny.Models
{
    public class PanelCutter : ApplicationUser
    {
        public PanelCutter() : base()
        { }

        public PanelCutter(string userName, string email) : base(userName, email)
        { }

        public string Opened { get; set; }

        public string Facebook { get; set; }

        public IList<string> Extras { get; set; }

        public SingleElement<Material> Materials { get; set; } = new SingleElement<Material>();

        public SingleElement<Closing> Closings { get; set; } = new SingleElement<Closing>();

        public SingleElement<Ad> Ads { get; set; } = new SingleElement<Ad>();
    }
}