using pmd_be.Models;

namespace pmd_be.Extensions;

internal static class DbExtensions
{
    public static IApplicationBuilder UseSeedData(this IApplicationBuilder app, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<PmdDbContext>();
            TestDbInitializer.Initialize(context, logger);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to seed database");
        }

        return app;
    }
}
