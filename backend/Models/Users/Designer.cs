using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace Furny.Models
{
	public class Designer : ApplicationUser
	{
		public Designer() : base()
		{ }

		public Designer(string userName, string email) : base(userName, email)
		{ }
	}
}
