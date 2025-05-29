using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Chat.Client.Common.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
