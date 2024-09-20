using BlazorAppState;
using BlazorAppState.Components;
using BlazorAppState.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<AppState>();
builder.Services.AddScoped<StateService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
