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

        public SingleElement<Material> Materials { get; set; } = new SingleElement<Material>();

        public SingleElement<Closing> Closings { get; set; } = new SingleElement<Closing>();

        public SingleElement<Ad> Ads { get; set; } = new SingleElement<Ad>();
    }
}