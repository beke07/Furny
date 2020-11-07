using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;

namespace Furny.Model
{
    public static class RoleNames
    {
        public static string Designer { get; set; } = "Designer";

        public static string PanelCutter { get; set; } = "PanelCutter";
    }

    public class ApplicationRole : MongoIdentityRole<ObjectId>
    {
        public ApplicationRole() : base()
        { }

        public ApplicationRole(string roleName) : base(roleName)
        { }
    }
}
