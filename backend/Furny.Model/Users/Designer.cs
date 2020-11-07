using Furny.Common.Models;

namespace Furny.Model
{
    public class Designer : ApplicationUser
	{
		public Designer() : base()
		{ }

		public Designer(string userName, string email) : base(userName, email)
		{ }

		public SingleElement<PanelCutter> Favorites { get; set; } = new SingleElement<PanelCutter>();

		public SingleElement<Furniture> Furnitures { get; set; } = new SingleElement<Furniture>();

		public SingleElement<Modul> Moduls { get; set; } = new SingleElement<Modul>();
	}
}
