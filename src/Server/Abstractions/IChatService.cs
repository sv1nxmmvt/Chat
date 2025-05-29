using Server.Models;

namespace Server.Abstractions
{
    public interface IChatService
    {
        Task<List<MessageDto>> GetMessagesAsync();
        Task<MessageDto> AddMessageAsync(string content, string userId, string username);
    }
}