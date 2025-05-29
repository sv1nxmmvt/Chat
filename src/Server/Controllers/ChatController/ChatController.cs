using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Abstractions;
using Server.Hubs;

namespace Server.Controllers.ChatController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public partial class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatController(IChatService chatService, IHubContext<ChatHub> hubContext)
        {
            _chatService = chatService;
            _hubContext = hubContext;
        }
    }
}