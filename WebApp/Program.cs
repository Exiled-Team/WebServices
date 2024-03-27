using WebApp.Deployment.Services;

namespace WebApp;

internal class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IConfigLoaderService, ConfigLoaderService>();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

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

        app.UseRouting();
        
        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");
        
        app.Run();
    }
}