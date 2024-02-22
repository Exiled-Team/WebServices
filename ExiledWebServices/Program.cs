using ExiledWebServices.Components;
using ExiledWebServices.Deployment;
using ExiledWebServices.Deployment.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IConfigLoaderService, ConfigLoaderService>();

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