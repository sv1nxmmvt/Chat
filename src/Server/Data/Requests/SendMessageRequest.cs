using System.ComponentModel.DataAnnotations;

namespace Chat.Server.API.Data.Requests;

public class SendMessageRequest
{
    [Required]
    public string Content { get; set; } = string.Empty;
}