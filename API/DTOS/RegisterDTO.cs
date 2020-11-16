using System.ComponentModel.DataAnnotations;

namespace DTOS
{
    public class RegisterDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
    }
}