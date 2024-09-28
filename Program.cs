using de.mydevtime.LicenseServer.Blazor.Components;
using Radzen;

namespace de.mydevtime.LicenseServer.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        builder.Services.AddScoped<ContextMenuService>();
        
        builder.Services.AddRadzenComponents();
        builder.Services.AddRadzenQueryStringThemeService();
        
        builder.Services.AddLocalization();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAntiforgery();
        app.MapRazorPages();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        app.MapControllers();

        app.Run();
    }
}