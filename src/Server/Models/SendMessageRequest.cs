using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class SendMessageRequest
    {
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}