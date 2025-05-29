using Chat.Client.Web.Server.Components;
using Chat.Client.Common.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Chat.Client.Common._Imports).Assembly,
        typeof(Chat.Client.Web.Webassembly._Imports).Assembly);

app.Run();
