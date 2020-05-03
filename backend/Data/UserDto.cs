using System.ComponentModel.DataAnnotations;

namespace Furny.Data
{
    public class RegisterDto
    {
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
