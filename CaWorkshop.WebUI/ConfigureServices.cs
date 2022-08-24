namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddControllersWithViews();

        services.AddRazorPages();

        services.AddOpenApiDocument(config =>
        {
            config.Title = "CaWorkshop API";
        });

        return services;
    }
}
