using Client.Web.Server.Components;
using Client.Common.Services;

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
        typeof(Client.Common._Imports).Assembly,
        typeof(Client.Web.Webassembly._Imports).Assembly);

app.Run();
