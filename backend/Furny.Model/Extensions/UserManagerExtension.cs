using Furny.Model;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Identity
{
    public static class UserManagerExtension
    {
        public static async Task<string> GetIdByEmailAsync(this UserManager<ApplicationUser> userManager, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return user.Id.ToString();
        }
    }
}
