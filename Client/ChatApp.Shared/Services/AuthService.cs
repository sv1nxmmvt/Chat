using Client.Common.Models;
using System.Text;
using System.Text.Json;

namespace ChatApp.Shared.Services;

public class AuthService
{
    private readonly HttpClient _http = new();
    private const string BaseUrl = "https://localhost:7000/api/auth";

    public string? Token { get; private set; }
    public string? Username { get; private set; }
    public bool IsAuthenticated => !string.IsNullOrEmpty(Token);

    public async Task<bool> LoginAsync(string username, string password)
    {
        var request = new { username, password };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _http.PostAsync($"{BaseUrl}/login", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<AuthResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Token = data?.Token;
                Username = data?.Username;
                return true;
            }
        }
        catch { }
        return false;
    }

    public async Task<bool> RegisterAsync(string username, string password)
    {
        var request = new { username, password };
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _http.PostAsync($"{BaseUrl}/register", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<AuthResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Token = data?.Token;
                Username = data?.Username;
                return true;
            }
        }
        catch { }
        return false;
    }

    public void Logout()
    {
        Token = null;
        Username = null;
    }
}