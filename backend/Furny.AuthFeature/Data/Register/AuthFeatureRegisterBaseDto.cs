using System.ComponentModel.DataAnnotations;

namespace Furny.AuthFeature.Data
{
    public abstract class AuthFeatureRegisterBaseDto
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordAgain { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public AuthFeatureUserAddressDto UserAddress { get; set; }
    }
}
