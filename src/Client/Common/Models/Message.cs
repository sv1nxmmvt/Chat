namespace Client.Common.Models;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public string Username { get; set; } = "";
}