using Client.Common.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace Client.Common.Services;

public class ChatService : INotifyPropertyChanged
{
    private readonly HttpClient _http = new();
    private HubConnection? _hubConnection;
    private const string BaseUrl = "https://localhost:7000";

    public ObservableCollection<Message> Messages { get; } = new();
    public bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;

    public event PropertyChangedEventHandler? PropertyChanged;

    public async Task ConnectAsync(string token)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{BaseUrl}/chatHub?access_token={token}")
            .Build();

        _hubConnection.On<Message>("ReceiveMessage", message =>
        {
            Messages.Add(message);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Messages)));
        });

        await _hubConnection.StartAsync();
        await LoadMessagesAsync(token);
    }

    public async Task SendMessageAsync(string content)
    {
        if (_hubConnection is not null)
            await _hubConnection.InvokeAsync("SendMessage", content);
    }

    public async Task DisconnectAsync()
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }
    }

    private async Task LoadMessagesAsync(string token)
    {
        try
        {
            _http.DefaultRequestHeaders.Authorization = new("Bearer", token);
            var response = await _http.GetAsync($"{BaseUrl}/api/chat/messages");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var messages = JsonSerializer.Deserialize<Message[]>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                Messages.Clear();
                if (messages != null)
                    foreach (var msg in messages)
                        Messages.Add(msg);
            }
        }
        catch { }
    }
}