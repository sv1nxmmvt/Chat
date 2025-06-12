using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers.AuthController
{
    public partial class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.LoginAsync(request);
            if (result == null)
                return Unauthorized("Invalid username or password");
            return Ok(result);
        }
    }
}