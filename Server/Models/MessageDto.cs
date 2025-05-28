namespace Server.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}