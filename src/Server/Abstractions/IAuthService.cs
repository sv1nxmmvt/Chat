using Server.Models;

namespace Server.Abstractions
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest request);
        Task<LoginResponse?> RegisterAsync(RegisterRequest request);
    }
}