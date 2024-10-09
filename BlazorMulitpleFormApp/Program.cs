using BlazorMulitpleFormApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddScoped<IStep1ApiService, DammyStep1ApiService>();
builder.Services.AddScoped<IStep2ApiService, DammyStep2ApiService>();
builder.Services.AddScoped<IStep3ApiService, DammyStep3ApiService>();
builder.Services.AddScoped<IStep4ApiService, DammyStep4ApiService>();


builder.Services.AddScoped<Step1Service>();
builder.Services.AddScoped<Step2Service>();
builder.Services.AddScoped<Step3Service>();
builder.Services.AddScoped<Step4Service>();
builder.Services.AddScoped<FormManagerService>();
await builder.Build().RunAsync();
