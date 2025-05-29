using Microsoft.AspNetCore.Mvc;
using Server.Abstractions;

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