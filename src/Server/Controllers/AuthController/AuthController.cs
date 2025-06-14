using Chat.Server.API.Logic.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.AuthController
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
    }
}