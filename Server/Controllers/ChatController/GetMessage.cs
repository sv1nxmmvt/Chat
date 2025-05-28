using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.ChatController
{
    public partial class ChatController : ControllerBase
    {
        [HttpGet("messages")]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _chatService.GetMessagesAsync();
            return Ok(messages);
        }
    }
}
