using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;

namespace Furny.Models
{
    public class ApplicationRole : MongoIdentityRole<ObjectId>
    {
		public ApplicationRole() : base()
		{ }

		public ApplicationRole(string roleName) : base(roleName)
		{ }
	}
}
