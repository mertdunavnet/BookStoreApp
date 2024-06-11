using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Dtos.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } // Will be username as well

        [Required]
        public string Password { get; set; }
    }
}
