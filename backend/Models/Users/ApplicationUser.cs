using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDbGenericRepository.Attributes;

namespace Furny.Models
{
	[CollectionName("Users")]
	public class ApplicationUser : MongoIdentityUser<ObjectId>
	{
		public ApplicationUser() : base()
		{ }

		public ApplicationUser(string userName, string email) : base(userName, email)
		{ }

		public string Name { get; set; }

		public string UserId { get; set; }

		public string ImageUrl { get; set; }
	}
}
