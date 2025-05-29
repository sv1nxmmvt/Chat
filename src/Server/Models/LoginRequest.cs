using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}