using ExiledWebServices.Components;
using ExiledWebServices.Deployment;

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