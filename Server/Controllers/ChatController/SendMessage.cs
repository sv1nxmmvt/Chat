using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Models;
using System.Security.Claims;

namespace Server.Controllers.ChatController
{
    public partial class ChatController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(username))
                return Unauthorized();
            var messageDto = await _chatService.AddMessageAsync(request.Content, userId, username);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", messageDto);
            return Ok(messageDto);
        }
    }
}