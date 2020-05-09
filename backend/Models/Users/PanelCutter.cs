using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;
using System.Collections.Generic;

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
    }
}