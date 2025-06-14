using Chat.Server.API.Data.Requests;
using Chat.Server.API.Data.Responses;

namespace Chat.Server.API.Logic.Abstractions;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(LoginRequest request);
    Task<LoginResponse?> RegisterAsync(RegisterRequest request);
}