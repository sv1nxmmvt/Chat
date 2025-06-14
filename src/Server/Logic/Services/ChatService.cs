using Chat.Server.API.Data.DTO;
using Chat.Server.API.Data.Models;
using Chat.Server.API.Logic.Abstractions;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Services;

public class ChatService : IChatService
{
    private readonly ChatDbContext _context;
    public ChatService(ChatDbContext context)
    {
        _context = context;
    }
    public async Task<List<MessageDto>> GetMessagesAsync()
    {
        var messages = await _context.Messages
            .Include(m => m.User)
            .OrderBy(m => m.Timestamp)
            .Select(m => new MessageDto
            {
                Id = m.Id,
                Content = m.Content,
                Timestamp = m.Timestamp,
                Username = m.User.UserName!
            })
            .ToListAsync();

        return messages;
    }
    public async Task<MessageDto> AddMessageAsync(string content, string userId, string username)
    {
        var message = new Message
        {
            Content = content,
            UserId = userId,
            Timestamp = DateTime.UtcNow
        };
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return new MessageDto
        {
            Id = message.Id,
            Content = message.Content,
            Timestamp = message.Timestamp,
            Username = username
        };
    }
}