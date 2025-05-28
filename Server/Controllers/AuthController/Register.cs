using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers.AuthController
{
    public partial class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                Console.WriteLine($"Registration attempt for user: {request.Username}");
                if (!ModelState.IsValid)
                {
                    Console.WriteLine($"Invalid model: {string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))}");
                    return BadRequest(ModelState);
                }
                var result = await _authService.RegisterAsync(request);
                if (result == null)
                {
                    Console.WriteLine("Registration failed");
                    return BadRequest("Username already exists or registration failed");
                }
                Console.WriteLine($"Registration successful for user: {request.Username}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Registration controller error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
