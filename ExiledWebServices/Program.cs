using System.Globalization;
using ExiledWebServices.Components;
using ExiledWebServices.Components.Core;
using ExiledWebServices.Components.Core.Interfaces;
using ExiledWebServices.Deployment;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using MudBlazor.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

Loader.LoadConfigs();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    builder.Services.AddHsts(options =>
    {
        options.MaxAge = TimeSpan.FromDays(60);
        options.IncludeSubDomains = true;
        options.Preload = true;
    });

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();