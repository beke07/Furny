using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace Furny.Models
{
	public class Designer : ApplicationUser
	{
		public Designer() : base()
		{ }

		public Designer(string userName, string email) : base(userName, email)
		{ }

		public SingleElement<PanelCutter> Favorites { get; set; } = new SingleElement<PanelCutter>();

		public SingleElement<Modul> Moduls { get; set; } = new SingleElement<Modul>();
	}
}
