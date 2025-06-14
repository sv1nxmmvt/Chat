using Chat.Server.API.Data.DTO;

namespace Chat.Server.API.Logic.Abstractions;

public interface IChatService
{
    Task<List<MessageDto>> GetMessagesAsync();
    Task<MessageDto> AddMessageAsync(string content, string userId, string username);
}