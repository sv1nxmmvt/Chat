using System.ComponentModel.DataAnnotations;

namespace Chat.Server.API.Data.Models;

public class Message
{
    public int Id { get; set; }
    [Required]
    public string Content { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    [Required]
    public string UserId { get; set; } = string.Empty;
    public virtual User User { get; set; } = null!;
}