using System.ComponentModel.DataAnnotations;

namespace Furny.AuthFeature.Data
{
    public class AuthFeatureLoginDto
    {
        [Required(ErrorMessage ="E-mail cím kötelező!")]
        [EmailAddress(ErrorMessage = "Helytelen e-mail formátum!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Jelszó kötelező!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
